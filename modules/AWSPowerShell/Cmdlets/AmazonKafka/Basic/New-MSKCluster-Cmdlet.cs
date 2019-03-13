/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Kafka;
using Amazon.Kafka.Model;

namespace Amazon.PowerShell.Cmdlets.MSK
{
    /// <summary>
    /// Creates a new MSK cluster.
    /// </summary>
    [Cmdlet("New", "MSKCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.CreateClusterResponse")]
    [AWSCmdlet("Calls the Managed Streaming for Kafka CreateCluster API operation.", Operation = new[] {"CreateCluster"})]
    [AWSCmdletOutput("Amazon.Kafka.Model.CreateClusterResponse",
        "This cmdlet returns a Amazon.Kafka.Model.CreateClusterResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMSKClusterCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        #region Parameter BrokerNodeGroupInfo
        /// <summary>
        /// <para>
        /// <para>Information about the broker nodes in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Kafka.Model.BrokerNodeGroupInfo BrokerNodeGroupInfo { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter EncryptionAtRest_DataVolumeKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key used for data encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EncryptionInfo_EncryptionAtRest_DataVolumeKMSKeyId")]
        public System.String EncryptionAtRest_DataVolumeKMSKeyId { get; set; }
        #endregion
        
        #region Parameter EnhancedMonitoring
        /// <summary>
        /// <para>
        /// <para>Specifies the level of monitoring for the MSK cluster. The possible values are DEFAULT,
        /// PER_BROKER, and PER_TOPIC_PER_BROKER.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Kafka.EnhancedMonitoring")]
        public Amazon.Kafka.EnhancedMonitoring EnhancedMonitoring { get; set; }
        #endregion
        
        #region Parameter KafkaVersion
        /// <summary>
        /// <para>
        /// <para>The version of Apache Kafka.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KafkaVersion { get; set; }
        #endregion
        
        #region Parameter NumberOfBrokerNode
        /// <summary>
        /// <para>
        /// <para>The number of Kafka broker nodes in the Amazon MSK cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NumberOfBrokerNodes")]
        public System.Int32 NumberOfBrokerNode { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MSKCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.BrokerNodeGroupInfo = this.BrokerNodeGroupInfo;
            context.ClusterName = this.ClusterName;
            context.EncryptionInfo_EncryptionAtRest_DataVolumeKMSKeyId = this.EncryptionAtRest_DataVolumeKMSKeyId;
            context.EnhancedMonitoring = this.EnhancedMonitoring;
            context.KafkaVersion = this.KafkaVersion;
            if (ParameterWasBound("NumberOfBrokerNode"))
                context.NumberOfBrokerNodes = this.NumberOfBrokerNode;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Kafka.Model.CreateClusterRequest();
            
            if (cmdletContext.BrokerNodeGroupInfo != null)
            {
                request.BrokerNodeGroupInfo = cmdletContext.BrokerNodeGroupInfo;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate EncryptionInfo
            bool requestEncryptionInfoIsNull = true;
            request.EncryptionInfo = new Amazon.Kafka.Model.EncryptionInfo();
            Amazon.Kafka.Model.EncryptionAtRest requestEncryptionInfo_encryptionInfo_EncryptionAtRest = null;
            
             // populate EncryptionAtRest
            bool requestEncryptionInfo_encryptionInfo_EncryptionAtRestIsNull = true;
            requestEncryptionInfo_encryptionInfo_EncryptionAtRest = new Amazon.Kafka.Model.EncryptionAtRest();
            System.String requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId = null;
            if (cmdletContext.EncryptionInfo_EncryptionAtRest_DataVolumeKMSKeyId != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId = cmdletContext.EncryptionInfo_EncryptionAtRest_DataVolumeKMSKeyId;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionAtRest.DataVolumeKMSKeyId = requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId;
                requestEncryptionInfo_encryptionInfo_EncryptionAtRestIsNull = false;
            }
             // determine if requestEncryptionInfo_encryptionInfo_EncryptionAtRest should be set to null
            if (requestEncryptionInfo_encryptionInfo_EncryptionAtRestIsNull)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionAtRest = null;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionAtRest != null)
            {
                request.EncryptionInfo.EncryptionAtRest = requestEncryptionInfo_encryptionInfo_EncryptionAtRest;
                requestEncryptionInfoIsNull = false;
            }
             // determine if request.EncryptionInfo should be set to null
            if (requestEncryptionInfoIsNull)
            {
                request.EncryptionInfo = null;
            }
            if (cmdletContext.EnhancedMonitoring != null)
            {
                request.EnhancedMonitoring = cmdletContext.EnhancedMonitoring;
            }
            if (cmdletContext.KafkaVersion != null)
            {
                request.KafkaVersion = cmdletContext.KafkaVersion;
            }
            if (cmdletContext.NumberOfBrokerNodes != null)
            {
                request.NumberOfBrokerNodes = cmdletContext.NumberOfBrokerNodes.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.Kafka.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed Streaming for Kafka", "CreateCluster");
            try
            {
                #if DESKTOP
                return client.CreateCluster(request);
                #elif CORECLR
                return client.CreateClusterAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Amazon.Kafka.Model.BrokerNodeGroupInfo BrokerNodeGroupInfo { get; set; }
            public System.String ClusterName { get; set; }
            public System.String EncryptionInfo_EncryptionAtRest_DataVolumeKMSKeyId { get; set; }
            public Amazon.Kafka.EnhancedMonitoring EnhancedMonitoring { get; set; }
            public System.String KafkaVersion { get; set; }
            public System.Int32? NumberOfBrokerNodes { get; set; }
        }
        
    }
}
