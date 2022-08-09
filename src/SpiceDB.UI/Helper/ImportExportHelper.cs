using SpiceDB.UI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceDB.UI.Helper
{
    internal class ImportExportHelper : IEventSubscriber
    {
        public void SubScribeEvents()
        {
            EventContainer.SubscribeEvent(EventType.StartImport.ToString(), StartImportHandler);
            EventContainer.SubscribeEvent(EventType.StartExport.ToString(), StartExportHandler);
        }

        public void UnSubScribeEvents()
        {
            EventContainer.UnSubscribeAll(this);
        }

        private bool ConfirmImport(string file)
        {
            var confirmResult = MessageBox.Show($"Are you sure to import {file}?",
                                     "Confirm Import!!",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return confirmResult == DialogResult.Yes;
        }
        private async void StartImportHandler(EventArg arg)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "yaml file |*.yaml";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                string file = openFileDialog1.FileName;

                if (!ConfirmImport(file))
                    return;

                var content = File.ReadAllText(file);

                SpiceDBService.Instance.ImportRelationships(content);
                await EventContainer.PublishEventAsync(EventType.LoadData.ToString());
                Cursor.Current = Cursors.Default;
            }
        }

        private void Export(TreeNode node, Dictionary<string, string> relationBucket)
        {
            foreach (TreeNode item in node.Nodes)
            {

                if (item.Checked && item.Tag != null)
                {
                    var relation = ((NodeTag)item.Tag).Relation;

                    if (relation != null)
                    {
                        var relationJson = $" {relation.Resource.ObjectType}:{relation.Resource.ObjectId}";

                        relationJson += $"#{relation.Relation}@{relation.Subject.Object.ObjectType}:{relation.Subject.Object.ObjectId}";

                        if (!string.IsNullOrWhiteSpace(relation.Subject.OptionalRelation))
                        {
                            relationJson += $"#{relation.Subject.OptionalRelation}";
                        }

                        CheckAndAddRelation(relationJson, relationBucket);
                    }
                }

                if (item.Nodes.Count > 0)
                {
                    this.Export(item, relationBucket);
                }
            }
        }
        private void CheckAndAddRelation(string relation, Dictionary<string, string> relationBuket)
        {
            if (!relationBuket.ContainsKey(relation))
            {
                relationBuket.Add(relation, relation);
            }
        }

        private void StartExportHandler(EventArg arg)
        {
            var _treeView1 = arg.Arg as TreeView;

            if (_treeView1.CheckBoxes)
            {
                Dictionary<string, string> relationBucket = new Dictionary<string, string>();
                Export(_treeView1.Nodes[0], relationBucket);

                if (relationBucket.Count > 0)
                {
                    var file = GetFileToSave();
                    if (!string.IsNullOrWhiteSpace(file))
                    {
                        StringBuilder sb = new StringBuilder();

                        foreach (var relation in relationBucket.Keys)
                        {
                            sb.AppendLine(relation + Environment.NewLine);
                        }

                        File.WriteAllText(file, "relationships: >-" + Environment.NewLine + sb.ToString());
                        MessageBox.Show($"Export Completed  {file}",
                            "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                EventContainer.PublishEvent(EventType.UpDateExportButtonText.ToString(), new EventArg("Export"));

                _treeView1.CheckBoxes = false;

            }
            else
            {
                if (_treeView1.Nodes.Count == 0)
                    return;

                Cursor.Current = Cursors.WaitCursor;
                _treeView1.CheckBoxes = true;
                _treeView1.ExpandAll();
                _treeView1.CollapseAll();
                _treeView1.Nodes[0].Expand();
                Cursor.Current = Cursors.Default;

                EventContainer.PublishEvent(EventType.UpDateExportButtonText.ToString(), new EventArg("CompleteExport"));

                MessageBox.Show("Select items(releationships) you want to export and click on complete export button",
                    "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetFileToSave()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Yaml File|*.yaml";
            saveFileDialog1.Title = "Save Export File";
            saveFileDialog1.ShowDialog();
            return saveFileDialog1.FileName;
        }


    }
}
