/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Creates a new Elasticsearch domain. For more information, see <a href="http://docs.aws.amazon.com/elasticsearch-service/latest/developerguide/es-createupdatedomains.html#es-createdomains" target="_blank">Creating Elasticsearch Domains</a> in the <i>Amazon Elasticsearch
    /// Service Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "ESDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Elasticsearch.Model.ElasticsearchDomainStatus")]
    [AWSCmdlet("Invokes the CreateElasticsearchDomain operation against Amazon Elasticsearch.", Operation = new[] {"CreateElasticsearchDomain"})]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.ElasticsearchDomainStatus",
        "This cmdlet returns a ElasticsearchDomainStatus object.",
        "The service call response (type Amazon.Elasticsearch.Model.CreateElasticsearchDomainResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewESDomainCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        #region Parameter AccessPolicy
        /// <summary>
        /// <para>
        /// <para> IAM access policy as a JSON-formatted string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccessPolicies")]
        public System.String AccessPolicy { get; set; }
        #endregion
        
        #region Parameter AdvancedOption
        /// <summary>
        /// <para>
        /// <para> Option to allow references to indices in an HTTP request body. Must be <code>false</code>
        /// when configuring access to individual sub-resources. By default, the value is <code>true</code>.
        /// See <a href="http://docs.aws.amazon.com/elasticsearch-service/latest/developerguide/es-createupdatedomains.html#es-createdomain-configure-advanced-options" target="_blank">Configuration Advanced Options</a> for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AdvancedOptions")]
        public System.Collections.Hashtable AdvancedOption { get; set; }
        #endregion
        
        #region Parameter SnapshotOptions_AutomatedSnapshotStartHour
        /// <summary>
        /// <para>
        /// <para>Specifies the time, in UTC format, when the service takes a daily automated snapshot
        /// of the specified Elasticsearch domain. Default value is <code>0</code> hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SnapshotOptions_AutomatedSnapshotStartHour { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_DedicatedMasterCount
        /// <summary>
        /// <para>
        /// <para>Total number of dedicated master nodes, active and on standby, for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ElasticsearchClusterConfig_DedicatedMasterCount { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_DedicatedMasterEnabled
        /// <summary>
        /// <para>
        /// <para>A boolean value to indicate whether a dedicated master node is enabled. See <a href="http://docs.aws.amazon.com/elasticsearch-service/latest/developerguide/es-managedomains.html#es-managedomains-dedicatedmasternodes" target="_blank">About Dedicated Master Nodes</a> for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ElasticsearchClusterConfig_DedicatedMasterEnabled { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_DedicatedMasterType
        /// <summary>
        /// <para>
        /// <para>The instance type for a dedicated master node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Elasticsearch.ESPartitionInstanceType")]
        public Amazon.Elasticsearch.ESPartitionInstanceType ElasticsearchClusterConfig_DedicatedMasterType { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the Elasticsearch domain that you are creating. Domain names are unique
        /// across the domains owned by an account within an AWS region. Domain names must start
        /// with a letter or number and can contain the following characters: a-z (lowercase),
        /// 0-9, and - (hyphen).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter EBSOptions_EBSEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether EBS-based storage is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EBSOptions_EBSEnabled { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances in the specified domain cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ElasticsearchClusterConfig_InstanceCount { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type for an Elasticsearch cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Elasticsearch.ESPartitionInstanceType")]
        public Amazon.Elasticsearch.ESPartitionInstanceType ElasticsearchClusterConfig_InstanceType { get; set; }
        #endregion
        
        #region Parameter EBSOptions_Iops
        /// <summary>
        /// <para>
        /// <para>Specifies the IOPD for a Provisioned IOPS EBS volume (SSD).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 EBSOptions_Iops { get; set; }
        #endregion
        
        #region Parameter EBSOptions_VolumeSize
        /// <summary>
        /// <para>
        /// <para> Integer to specify the size of an EBS volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 EBSOptions_VolumeSize { get; set; }
        #endregion
        
        #region Parameter EBSOptions_VolumeType
        /// <summary>
        /// <para>
        /// <para> Specifies the volume type for EBS-based storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Elasticsearch.VolumeType")]
        public Amazon.Elasticsearch.VolumeType EBSOptions_VolumeType { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_ZoneAwarenessEnabled
        /// <summary>
        /// <para>
        /// <para>A boolean value to indicate whether zone awareness is enabled. See <a href="http://docs.aws.amazon.com/elasticsearch-service/latest/developerguide/es-managedomains.html#es-managedomains-zoneawareness" target="_blank">About Zone Awareness</a> for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ElasticsearchClusterConfig_ZoneAwarenessEnabled { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ESDomain (CreateElasticsearchDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AccessPolicies = this.AccessPolicy;
            if (this.AdvancedOption != null)
            {
                context.AdvancedOptions = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdvancedOption.Keys)
                {
                    context.AdvancedOptions.Add((String)hashKey, (String)(this.AdvancedOption[hashKey]));
                }
            }
            context.DomainName = this.DomainName;
            if (ParameterWasBound("EBSOptions_EBSEnabled"))
                context.EBSOptions_EBSEnabled = this.EBSOptions_EBSEnabled;
            if (ParameterWasBound("EBSOptions_Iops"))
                context.EBSOptions_Iops = this.EBSOptions_Iops;
            if (ParameterWasBound("EBSOptions_VolumeSize"))
                context.EBSOptions_VolumeSize = this.EBSOptions_VolumeSize;
            context.EBSOptions_VolumeType = this.EBSOptions_VolumeType;
            if (ParameterWasBound("ElasticsearchClusterConfig_DedicatedMasterCount"))
                context.ElasticsearchClusterConfig_DedicatedMasterCount = this.ElasticsearchClusterConfig_DedicatedMasterCount;
            if (ParameterWasBound("ElasticsearchClusterConfig_DedicatedMasterEnabled"))
                context.ElasticsearchClusterConfig_DedicatedMasterEnabled = this.ElasticsearchClusterConfig_DedicatedMasterEnabled;
            context.ElasticsearchClusterConfig_DedicatedMasterType = this.ElasticsearchClusterConfig_DedicatedMasterType;
            if (ParameterWasBound("ElasticsearchClusterConfig_InstanceCount"))
                context.ElasticsearchClusterConfig_InstanceCount = this.ElasticsearchClusterConfig_InstanceCount;
            context.ElasticsearchClusterConfig_InstanceType = this.ElasticsearchClusterConfig_InstanceType;
            if (ParameterWasBound("ElasticsearchClusterConfig_ZoneAwarenessEnabled"))
                context.ElasticsearchClusterConfig_ZoneAwarenessEnabled = this.ElasticsearchClusterConfig_ZoneAwarenessEnabled;
            if (ParameterWasBound("SnapshotOptions_AutomatedSnapshotStartHour"))
                context.SnapshotOptions_AutomatedSnapshotStartHour = this.SnapshotOptions_AutomatedSnapshotStartHour;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Elasticsearch.Model.CreateElasticsearchDomainRequest();
            
            if (cmdletContext.AccessPolicies != null)
            {
                request.AccessPolicies = cmdletContext.AccessPolicies;
            }
            if (cmdletContext.AdvancedOptions != null)
            {
                request.AdvancedOptions = cmdletContext.AdvancedOptions;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate EBSOptions
            bool requestEBSOptionsIsNull = true;
            request.EBSOptions = new Amazon.Elasticsearch.Model.EBSOptions();
            System.Boolean? requestEBSOptions_eBSOptions_EBSEnabled = null;
            if (cmdletContext.EBSOptions_EBSEnabled != null)
            {
                requestEBSOptions_eBSOptions_EBSEnabled = cmdletContext.EBSOptions_EBSEnabled.Value;
            }
            if (requestEBSOptions_eBSOptions_EBSEnabled != null)
            {
                request.EBSOptions.EBSEnabled = requestEBSOptions_eBSOptions_EBSEnabled.Value;
                requestEBSOptionsIsNull = false;
            }
            System.Int32? requestEBSOptions_eBSOptions_Iops = null;
            if (cmdletContext.EBSOptions_Iops != null)
            {
                requestEBSOptions_eBSOptions_Iops = cmdletContext.EBSOptions_Iops.Value;
            }
            if (requestEBSOptions_eBSOptions_Iops != null)
            {
                request.EBSOptions.Iops = requestEBSOptions_eBSOptions_Iops.Value;
                requestEBSOptionsIsNull = false;
            }
            System.Int32? requestEBSOptions_eBSOptions_VolumeSize = null;
            if (cmdletContext.EBSOptions_VolumeSize != null)
            {
                requestEBSOptions_eBSOptions_VolumeSize = cmdletContext.EBSOptions_VolumeSize.Value;
            }
            if (requestEBSOptions_eBSOptions_VolumeSize != null)
            {
                request.EBSOptions.VolumeSize = requestEBSOptions_eBSOptions_VolumeSize.Value;
                requestEBSOptionsIsNull = false;
            }
            Amazon.Elasticsearch.VolumeType requestEBSOptions_eBSOptions_VolumeType = null;
            if (cmdletContext.EBSOptions_VolumeType != null)
            {
                requestEBSOptions_eBSOptions_VolumeType = cmdletContext.EBSOptions_VolumeType;
            }
            if (requestEBSOptions_eBSOptions_VolumeType != null)
            {
                request.EBSOptions.VolumeType = requestEBSOptions_eBSOptions_VolumeType;
                requestEBSOptionsIsNull = false;
            }
             // determine if request.EBSOptions should be set to null
            if (requestEBSOptionsIsNull)
            {
                request.EBSOptions = null;
            }
            
             // populate ElasticsearchClusterConfig
            bool requestElasticsearchClusterConfigIsNull = true;
            request.ElasticsearchClusterConfig = new Amazon.Elasticsearch.Model.ElasticsearchClusterConfig();
            System.Int32? requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterCount = null;
            if (cmdletContext.ElasticsearchClusterConfig_DedicatedMasterCount != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterCount = cmdletContext.ElasticsearchClusterConfig_DedicatedMasterCount.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterCount != null)
            {
                request.ElasticsearchClusterConfig.DedicatedMasterCount = requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterCount.Value;
                requestElasticsearchClusterConfigIsNull = false;
            }
            System.Boolean? requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterEnabled = null;
            if (cmdletContext.ElasticsearchClusterConfig_DedicatedMasterEnabled != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterEnabled = cmdletContext.ElasticsearchClusterConfig_DedicatedMasterEnabled.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterEnabled != null)
            {
                request.ElasticsearchClusterConfig.DedicatedMasterEnabled = requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterEnabled.Value;
                requestElasticsearchClusterConfigIsNull = false;
            }
            Amazon.Elasticsearch.ESPartitionInstanceType requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterType = null;
            if (cmdletContext.ElasticsearchClusterConfig_DedicatedMasterType != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterType = cmdletContext.ElasticsearchClusterConfig_DedicatedMasterType;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterType != null)
            {
                request.ElasticsearchClusterConfig.DedicatedMasterType = requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterType;
                requestElasticsearchClusterConfigIsNull = false;
            }
            System.Int32? requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceCount = null;
            if (cmdletContext.ElasticsearchClusterConfig_InstanceCount != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceCount = cmdletContext.ElasticsearchClusterConfig_InstanceCount.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceCount != null)
            {
                request.ElasticsearchClusterConfig.InstanceCount = requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceCount.Value;
                requestElasticsearchClusterConfigIsNull = false;
            }
            Amazon.Elasticsearch.ESPartitionInstanceType requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceType = null;
            if (cmdletContext.ElasticsearchClusterConfig_InstanceType != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceType = cmdletContext.ElasticsearchClusterConfig_InstanceType;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceType != null)
            {
                request.ElasticsearchClusterConfig.InstanceType = requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceType;
                requestElasticsearchClusterConfigIsNull = false;
            }
            System.Boolean? requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessEnabled = null;
            if (cmdletContext.ElasticsearchClusterConfig_ZoneAwarenessEnabled != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessEnabled = cmdletContext.ElasticsearchClusterConfig_ZoneAwarenessEnabled.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessEnabled != null)
            {
                request.ElasticsearchClusterConfig.ZoneAwarenessEnabled = requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessEnabled.Value;
                requestElasticsearchClusterConfigIsNull = false;
            }
             // determine if request.ElasticsearchClusterConfig should be set to null
            if (requestElasticsearchClusterConfigIsNull)
            {
                request.ElasticsearchClusterConfig = null;
            }
            
             // populate SnapshotOptions
            bool requestSnapshotOptionsIsNull = true;
            request.SnapshotOptions = new Amazon.Elasticsearch.Model.SnapshotOptions();
            System.Int32? requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour = null;
            if (cmdletContext.SnapshotOptions_AutomatedSnapshotStartHour != null)
            {
                requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour = cmdletContext.SnapshotOptions_AutomatedSnapshotStartHour.Value;
            }
            if (requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour != null)
            {
                request.SnapshotOptions.AutomatedSnapshotStartHour = requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour.Value;
                requestSnapshotOptionsIsNull = false;
            }
             // determine if request.SnapshotOptions should be set to null
            if (requestSnapshotOptionsIsNull)
            {
                request.SnapshotOptions = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DomainStatus;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private static Amazon.Elasticsearch.Model.CreateElasticsearchDomainResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.CreateElasticsearchDomainRequest request)
        {
            return client.CreateElasticsearchDomain(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AccessPolicies { get; set; }
            public Dictionary<System.String, System.String> AdvancedOptions { get; set; }
            public System.String DomainName { get; set; }
            public System.Boolean? EBSOptions_EBSEnabled { get; set; }
            public System.Int32? EBSOptions_Iops { get; set; }
            public System.Int32? EBSOptions_VolumeSize { get; set; }
            public Amazon.Elasticsearch.VolumeType EBSOptions_VolumeType { get; set; }
            public System.Int32? ElasticsearchClusterConfig_DedicatedMasterCount { get; set; }
            public System.Boolean? ElasticsearchClusterConfig_DedicatedMasterEnabled { get; set; }
            public Amazon.Elasticsearch.ESPartitionInstanceType ElasticsearchClusterConfig_DedicatedMasterType { get; set; }
            public System.Int32? ElasticsearchClusterConfig_InstanceCount { get; set; }
            public Amazon.Elasticsearch.ESPartitionInstanceType ElasticsearchClusterConfig_InstanceType { get; set; }
            public System.Boolean? ElasticsearchClusterConfig_ZoneAwarenessEnabled { get; set; }
            public System.Int32? SnapshotOptions_AutomatedSnapshotStartHour { get; set; }
        }
        
    }
}
