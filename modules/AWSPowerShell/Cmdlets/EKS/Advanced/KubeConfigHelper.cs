/*******************************************************************************
 *  Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using Amazon.EKS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    internal static class KubeConfigHelper
    {
        const string ApiVersion = "client.authentication.k8s.io/v1beta1";
        public static string DefaultKubeConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".kube", "config");


        public static YamlMappingNode NewKubeConfig =>
            new YamlMappingNode
            {
                { "apiVersion", "v1" },
                { "clusters", new YamlSequenceNode() },
                { "contexts", new YamlSequenceNode() },
                { "current-context", "" },
                { "kind", "Config" },
                { "preferences" , new YamlMappingNode() },
                { "users",  new YamlSequenceNode() }
            };

        public static YamlMappingNode UpdateCubeConfig(DescribeClusterResponse response, string kubeConfigPath, string roleArn, string profileName, string alias, string userAlias, out string configPath)
        {
            configPath = KubeConfigHelper.DefaultKubeConfigPath;

            if (kubeConfigPath != null)
            {
                configPath = Path.GetFullPath(kubeConfigPath);
            }

            string configDirectoryName = Path.GetDirectoryName(configPath);
            if (configDirectoryName != null && !Directory.Exists(configDirectoryName))
            {
                Directory.CreateDirectory(configDirectoryName);
            }

            string text = File.ReadAllText(configPath, Encoding.UTF8).Trim();

            YamlStream yamlStream;

            if (string.IsNullOrWhiteSpace(text))
            {
                yamlStream = new YamlStream(new YamlDocument(KubeConfigHelper.NewKubeConfig));
            }
            else
            {
                yamlStream = new YamlStream(new YamlDocument(new YamlMappingNode()));
                yamlStream.Load(new StringReader(text));
            }

            var config = (YamlMappingNode)yamlStream.Documents[0].RootNode;

            var newContext = KubeConfigHelper.UpdateConfig(
                config,
                KubeConfigHelper.GetClusterEntry(response.Cluster),
                KubeConfigHelper.GetUserEntry(response.Cluster, roleArn, profileName, userAlias),
                alias);

            var serializer = new Serializer();
            using (var fs = File.OpenWrite(configPath))
            using (var stringWriter = new StreamWriter(fs))
            {
                serializer.Serialize(stringWriter, yamlStream.Documents[0].RootNode);
            }

            return newContext;
        }

        /// <summary>
        /// Inserts a new entry into a YAML configuration.
        /// </summary>
        private static void InsertEntry(YamlMappingNode config, string key, YamlMappingNode newEntry)
        {
            var namedItems = new Dictionary<string, YamlMappingNode>();

            var origNamedItems = config[new YamlScalarNode(key)] as YamlSequenceNode;
            if (origNamedItems == null)
            {
                throw new Exception("The kubeconfig file is invalid");
            }
            foreach (var entries in origNamedItems.Children.Cast<YamlMappingNode>())
            {
                var nameNode = entries.Children[new YamlScalarNode("name")] as YamlScalarNode;
                if (!namedItems.ContainsKey(nameNode.Value))
                {
                    namedItems.Add(nameNode.Value, entries);
                }
            }

            var nameNode2 = newEntry.Children[new YamlScalarNode("name")] as YamlScalarNode;
            if (!namedItems.ContainsKey(nameNode2.Value))
            {
                namedItems.Add(nameNode2.Value, newEntry);
            }
            else
            {
                namedItems[nameNode2.Value] = newEntry;
            }

            config.Children[new YamlScalarNode(key)] = new YamlSequenceNode(namedItems.Values);
        }

        /// <summary>
        /// Insert the passed cluster entry and user entry, then make a context to associate them
        /// and set current-context to be the new context.
        /// </summary>
        /// <returns>Returns the new context</returns>
        public static YamlMappingNode UpdateConfig(YamlMappingNode config, YamlMappingNode cluster, YamlMappingNode user, string alias = null)
        {
            var clusterName = (cluster.Children[new YamlScalarNode("name")] as YamlScalarNode)?.Value;
            var userName = (user.Children[new YamlScalarNode("name")] as YamlScalarNode)?.Value;

            var context = MakeContext(clusterName, userName, alias);

            InsertEntry(config, "clusters", cluster);
            InsertEntry(config, "users", user);
            InsertEntry(config, "contexts", context);

            config.Children[new YamlScalarNode("current-context")] = context.Children[new YamlScalarNode("name")];

            return context;
        }

        /// <summary>
        /// Generate a context to associate cluster and user with a given alias.
        /// </summary>
        public static YamlMappingNode MakeContext(string clusterName, string userName, string alias = null)
        {
            var contextNode = new YamlMappingNode
            {
                {
                    "context", new YamlMappingNode
                    {
                        { "cluster", clusterName },
                        { "user",  userName}
                    }
                },
                { "name" , alias ?? userName }
            };

            return contextNode;
        }

        /// <summary>
        /// Return a cluster entry generated using the previously obtained description.
        /// </summary>
        public static YamlMappingNode GetClusterEntry(Cluster clusterDescription)
        {
            var arn = clusterDescription.Arn;
            var endpoint = clusterDescription.Endpoint;
            var certificateAuthorityData = clusterDescription.CertificateAuthority?.Data ?? "";

            var clusterEntry = new YamlMappingNode
            {
                {
                    "cluster", new YamlMappingNode
                    {
                        { "certificate-authority-data", certificateAuthorityData },
                        { "server", endpoint }
                    }
                },
                { "name", arn }
            };

            return clusterEntry;
        }

        /// <summary>
        /// Return a user entry generated using the previously obtained description.
        /// </summary>
        public static YamlMappingNode GetUserEntry(Cluster cluster, string roleArn, string profileName, string userAlias = null)
        {
            var region = cluster.Arn.Split(':')[3];
            var outpostConfig = cluster.OutpostConfig;

            string clusterIdentificationParameter;
            string clusterIdentificationValue;

            if (outpostConfig != null)
            {
                clusterIdentificationParameter = "--cluster-id";
                clusterIdentificationValue = cluster.Id;
            }
            else
            {
                clusterIdentificationParameter = "--cluster-name";
                clusterIdentificationValue = cluster.Name;
            }

            var argumentsNode = new YamlSequenceNode
            {
                "--region",
                region,
                "eks",
                "get-token",
                clusterIdentificationParameter,
                clusterIdentificationValue,
                "--output",
                "json"
            };


            var executionNode = new YamlMappingNode
            {
                { "apiVersion", ApiVersion },
                { "args", argumentsNode },
                { "command", "aws" }
            };

            var userEntry = new YamlMappingNode
            {
                { "name", userAlias ?? cluster.Arn ?? "" },
                {
                    "user", new YamlMappingNode
                    {
                        { "exec", executionNode }
                    }
                }
            };

            if (roleArn != null)
            {
                argumentsNode.Add("--role");
                argumentsNode.Add(roleArn);
            }


            if (profileName != null)
            {
                executionNode.Add("env", new YamlSequenceNode
                {
                    new YamlMappingNode
                    {
                        { "name", "AWS_PROFILE"  },
                        { "value", profileName }
                    }
                });
            }

            return userEntry;
        }
    }
}
