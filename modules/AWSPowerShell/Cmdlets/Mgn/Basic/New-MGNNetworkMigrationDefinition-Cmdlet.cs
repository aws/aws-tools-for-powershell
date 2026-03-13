/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Mgn;
using Amazon.Mgn.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Creates a new network migration definition that specifies the source and target network
    /// configuration for a migration.
    /// </summary>
    [Cmdlet("New", "MGNNetworkMigrationDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.CreateNetworkMigrationDefinitionResponse")]
    [AWSCmdlet("Calls the Application Migration Service CreateNetworkMigrationDefinition API operation.", Operation = new[] {"CreateNetworkMigrationDefinition"}, SelectReturnType = typeof(Amazon.Mgn.Model.CreateNetworkMigrationDefinitionResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.CreateNetworkMigrationDefinitionResponse",
        "This cmdlet returns an Amazon.Mgn.Model.CreateNetworkMigrationDefinitionResponse object containing multiple properties."
    )]
    public partial class NewMGNNetworkMigrationDefinitionCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the network migration definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TargetNetwork_InboundCidr
        /// <summary>
        /// <para>
        /// <para>The CIDR block for inbound traffic in the target network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetNetwork_InboundCidr { get; set; }
        #endregion
        
        #region Parameter TargetNetwork_InspectionCidr
        /// <summary>
        /// <para>
        /// <para>The CIDR block for inspection traffic in the target network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetNetwork_InspectionCidr { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the network migration definition.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TargetNetwork_OutboundCidr
        /// <summary>
        /// <para>
        /// <para>The CIDR block for outbound traffic in the target network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetNetwork_OutboundCidr { get; set; }
        #endregion
        
        #region Parameter TargetS3Configuration_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket for target artifacts.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TargetS3Configuration_S3Bucket { get; set; }
        #endregion
        
        #region Parameter TargetS3Configuration_S3BucketOwner
        /// <summary>
        /// <para>
        /// <para>The AWS account ID of the S3 bucket owner.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TargetS3Configuration_S3BucketOwner { get; set; }
        #endregion
        
        #region Parameter ScopeTag
        /// <summary>
        /// <para>
        /// <para>Scope tags for the network migration definition to control access and organization.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScopeTags")]
        public System.Collections.Hashtable ScopeTag { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of source configurations for the network migration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfigurations")]
        public Amazon.Mgn.Model.SourceConfiguration[] SourceConfiguration { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the network migration definition.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TargetDeployment
        /// <summary>
        /// <para>
        /// <para>The target deployment configuration for the migrated network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.TargetDeployment")]
        public Amazon.Mgn.TargetDeployment TargetDeployment { get; set; }
        #endregion
        
        #region Parameter TargetNetwork_Topology
        /// <summary>
        /// <para>
        /// <para>The network topology type for the target environment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Mgn.TargetNetworkTopology")]
        public Amazon.Mgn.TargetNetworkTopology TargetNetwork_Topology { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.CreateNetworkMigrationDefinitionResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.CreateNetworkMigrationDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MGNNetworkMigrationDefinition (CreateNetworkMigrationDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.CreateNetworkMigrationDefinitionResponse, NewMGNNetworkMigrationDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ScopeTag != null)
            {
                context.ScopeTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ScopeTag.Keys)
                {
                    context.ScopeTag.Add((String)hashKey, (System.String)(this.ScopeTag[hashKey]));
                }
            }
            if (this.SourceConfiguration != null)
            {
                context.SourceConfiguration = new List<Amazon.Mgn.Model.SourceConfiguration>(this.SourceConfiguration);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TargetDeployment = this.TargetDeployment;
            context.TargetNetwork_InboundCidr = this.TargetNetwork_InboundCidr;
            context.TargetNetwork_InspectionCidr = this.TargetNetwork_InspectionCidr;
            context.TargetNetwork_OutboundCidr = this.TargetNetwork_OutboundCidr;
            context.TargetNetwork_Topology = this.TargetNetwork_Topology;
            #if MODULAR
            if (this.TargetNetwork_Topology == null && ParameterWasBound(nameof(this.TargetNetwork_Topology)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetNetwork_Topology which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetS3Configuration_S3Bucket = this.TargetS3Configuration_S3Bucket;
            #if MODULAR
            if (this.TargetS3Configuration_S3Bucket == null && ParameterWasBound(nameof(this.TargetS3Configuration_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetS3Configuration_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetS3Configuration_S3BucketOwner = this.TargetS3Configuration_S3BucketOwner;
            #if MODULAR
            if (this.TargetS3Configuration_S3BucketOwner == null && ParameterWasBound(nameof(this.TargetS3Configuration_S3BucketOwner)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetS3Configuration_S3BucketOwner which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Mgn.Model.CreateNetworkMigrationDefinitionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ScopeTag != null)
            {
                request.ScopeTags = cmdletContext.ScopeTag;
            }
            if (cmdletContext.SourceConfiguration != null)
            {
                request.SourceConfigurations = cmdletContext.SourceConfiguration;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetDeployment != null)
            {
                request.TargetDeployment = cmdletContext.TargetDeployment;
            }
            
             // populate TargetNetwork
            var requestTargetNetworkIsNull = true;
            request.TargetNetwork = new Amazon.Mgn.Model.TargetNetwork();
            System.String requestTargetNetwork_targetNetwork_InboundCidr = null;
            if (cmdletContext.TargetNetwork_InboundCidr != null)
            {
                requestTargetNetwork_targetNetwork_InboundCidr = cmdletContext.TargetNetwork_InboundCidr;
            }
            if (requestTargetNetwork_targetNetwork_InboundCidr != null)
            {
                request.TargetNetwork.InboundCidr = requestTargetNetwork_targetNetwork_InboundCidr;
                requestTargetNetworkIsNull = false;
            }
            System.String requestTargetNetwork_targetNetwork_InspectionCidr = null;
            if (cmdletContext.TargetNetwork_InspectionCidr != null)
            {
                requestTargetNetwork_targetNetwork_InspectionCidr = cmdletContext.TargetNetwork_InspectionCidr;
            }
            if (requestTargetNetwork_targetNetwork_InspectionCidr != null)
            {
                request.TargetNetwork.InspectionCidr = requestTargetNetwork_targetNetwork_InspectionCidr;
                requestTargetNetworkIsNull = false;
            }
            System.String requestTargetNetwork_targetNetwork_OutboundCidr = null;
            if (cmdletContext.TargetNetwork_OutboundCidr != null)
            {
                requestTargetNetwork_targetNetwork_OutboundCidr = cmdletContext.TargetNetwork_OutboundCidr;
            }
            if (requestTargetNetwork_targetNetwork_OutboundCidr != null)
            {
                request.TargetNetwork.OutboundCidr = requestTargetNetwork_targetNetwork_OutboundCidr;
                requestTargetNetworkIsNull = false;
            }
            Amazon.Mgn.TargetNetworkTopology requestTargetNetwork_targetNetwork_Topology = null;
            if (cmdletContext.TargetNetwork_Topology != null)
            {
                requestTargetNetwork_targetNetwork_Topology = cmdletContext.TargetNetwork_Topology;
            }
            if (requestTargetNetwork_targetNetwork_Topology != null)
            {
                request.TargetNetwork.Topology = requestTargetNetwork_targetNetwork_Topology;
                requestTargetNetworkIsNull = false;
            }
             // determine if request.TargetNetwork should be set to null
            if (requestTargetNetworkIsNull)
            {
                request.TargetNetwork = null;
            }
            
             // populate TargetS3Configuration
            var requestTargetS3ConfigurationIsNull = true;
            request.TargetS3Configuration = new Amazon.Mgn.Model.TargetS3Configuration();
            System.String requestTargetS3Configuration_targetS3Configuration_S3Bucket = null;
            if (cmdletContext.TargetS3Configuration_S3Bucket != null)
            {
                requestTargetS3Configuration_targetS3Configuration_S3Bucket = cmdletContext.TargetS3Configuration_S3Bucket;
            }
            if (requestTargetS3Configuration_targetS3Configuration_S3Bucket != null)
            {
                request.TargetS3Configuration.S3Bucket = requestTargetS3Configuration_targetS3Configuration_S3Bucket;
                requestTargetS3ConfigurationIsNull = false;
            }
            System.String requestTargetS3Configuration_targetS3Configuration_S3BucketOwner = null;
            if (cmdletContext.TargetS3Configuration_S3BucketOwner != null)
            {
                requestTargetS3Configuration_targetS3Configuration_S3BucketOwner = cmdletContext.TargetS3Configuration_S3BucketOwner;
            }
            if (requestTargetS3Configuration_targetS3Configuration_S3BucketOwner != null)
            {
                request.TargetS3Configuration.S3BucketOwner = requestTargetS3Configuration_targetS3Configuration_S3BucketOwner;
                requestTargetS3ConfigurationIsNull = false;
            }
             // determine if request.TargetS3Configuration should be set to null
            if (requestTargetS3ConfigurationIsNull)
            {
                request.TargetS3Configuration = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.Mgn.Model.CreateNetworkMigrationDefinitionResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.CreateNetworkMigrationDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "CreateNetworkMigrationDefinition");
            try
            {
                return client.CreateNetworkMigrationDefinitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> ScopeTag { get; set; }
            public List<Amazon.Mgn.Model.SourceConfiguration> SourceConfiguration { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Mgn.TargetDeployment TargetDeployment { get; set; }
            public System.String TargetNetwork_InboundCidr { get; set; }
            public System.String TargetNetwork_InspectionCidr { get; set; }
            public System.String TargetNetwork_OutboundCidr { get; set; }
            public Amazon.Mgn.TargetNetworkTopology TargetNetwork_Topology { get; set; }
            public System.String TargetS3Configuration_S3Bucket { get; set; }
            public System.String TargetS3Configuration_S3BucketOwner { get; set; }
            public System.Func<Amazon.Mgn.Model.CreateNetworkMigrationDefinitionResponse, NewMGNNetworkMigrationDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
