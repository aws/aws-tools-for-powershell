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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Updates an existing network migration definition with new source or target configurations.
    /// </summary>
    [Cmdlet("Update", "MGNNetworkMigrationDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionResponse")]
    [AWSCmdlet("Calls the Application Migration Service UpdateNetworkMigrationDefinition API operation.", Operation = new[] {"UpdateNetworkMigrationDefinition"}, SelectReturnType = typeof(Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionResponse",
        "This cmdlet returns an Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionResponse object containing multiple properties."
    )]
    public partial class UpdateMGNNetworkMigrationDefinitionCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of the network migration definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TargetNetwork_InboundCidr
        /// <summary>
        /// <para>
        /// <para>The updated CIDR block for inbound traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetNetwork_InboundCidr { get; set; }
        #endregion
        
        #region Parameter TargetNetwork_InspectionCidr
        /// <summary>
        /// <para>
        /// <para>The updated CIDR block for inspection traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetNetwork_InspectionCidr { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name of the network migration definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NetworkMigrationDefinitionID
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the network migration definition to update.</para>
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
        public System.String NetworkMigrationDefinitionID { get; set; }
        #endregion
        
        #region Parameter TargetNetwork_OutboundCidr
        /// <summary>
        /// <para>
        /// <para>The updated CIDR block for outbound traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetNetwork_OutboundCidr { get; set; }
        #endregion
        
        #region Parameter TargetS3Configuration_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The updated name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetS3Configuration_S3Bucket { get; set; }
        #endregion
        
        #region Parameter TargetS3Configuration_S3BucketOwner
        /// <summary>
        /// <para>
        /// <para>The updated AWS account ID of the S3 bucket owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetS3Configuration_S3BucketOwner { get; set; }
        #endregion
        
        #region Parameter ScopeTag
        /// <summary>
        /// <para>
        /// <para>The updated scope tags for the network migration definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScopeTags")]
        public System.Collections.Hashtable ScopeTag { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration
        /// <summary>
        /// <para>
        /// <para>The updated list of source configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfigurations")]
        public Amazon.Mgn.Model.SourceConfiguration[] SourceConfiguration { get; set; }
        #endregion
        
        #region Parameter TargetDeployment
        /// <summary>
        /// <para>
        /// <para>The updated target deployment configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.TargetDeployment")]
        public Amazon.Mgn.TargetDeployment TargetDeployment { get; set; }
        #endregion
        
        #region Parameter TargetNetwork_Topology
        /// <summary>
        /// <para>
        /// <para>The updated network topology type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.TargetNetworkTopology")]
        public Amazon.Mgn.TargetNetworkTopology TargetNetwork_Topology { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkMigrationDefinitionID parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkMigrationDefinitionID' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkMigrationDefinitionID' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkMigrationDefinitionID), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGNNetworkMigrationDefinition (UpdateNetworkMigrationDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionResponse, UpdateMGNNetworkMigrationDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkMigrationDefinitionID;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.Name = this.Name;
            context.NetworkMigrationDefinitionID = this.NetworkMigrationDefinitionID;
            #if MODULAR
            if (this.NetworkMigrationDefinitionID == null && ParameterWasBound(nameof(this.NetworkMigrationDefinitionID)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkMigrationDefinitionID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.TargetDeployment = this.TargetDeployment;
            context.TargetNetwork_InboundCidr = this.TargetNetwork_InboundCidr;
            context.TargetNetwork_InspectionCidr = this.TargetNetwork_InspectionCidr;
            context.TargetNetwork_OutboundCidr = this.TargetNetwork_OutboundCidr;
            context.TargetNetwork_Topology = this.TargetNetwork_Topology;
            context.TargetS3Configuration_S3Bucket = this.TargetS3Configuration_S3Bucket;
            context.TargetS3Configuration_S3BucketOwner = this.TargetS3Configuration_S3BucketOwner;
            
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
            var request = new Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NetworkMigrationDefinitionID != null)
            {
                request.NetworkMigrationDefinitionID = cmdletContext.NetworkMigrationDefinitionID;
            }
            if (cmdletContext.ScopeTag != null)
            {
                request.ScopeTags = cmdletContext.ScopeTag;
            }
            if (cmdletContext.SourceConfiguration != null)
            {
                request.SourceConfigurations = cmdletContext.SourceConfiguration;
            }
            if (cmdletContext.TargetDeployment != null)
            {
                request.TargetDeployment = cmdletContext.TargetDeployment;
            }
            
             // populate TargetNetwork
            var requestTargetNetworkIsNull = true;
            request.TargetNetwork = new Amazon.Mgn.Model.TargetNetworkUpdate();
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
            request.TargetS3Configuration = new Amazon.Mgn.Model.TargetS3ConfigurationUpdate();
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
        
        private Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "UpdateNetworkMigrationDefinition");
            try
            {
                #if DESKTOP
                return client.UpdateNetworkMigrationDefinition(request);
                #elif CORECLR
                return client.UpdateNetworkMigrationDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String NetworkMigrationDefinitionID { get; set; }
            public Dictionary<System.String, System.String> ScopeTag { get; set; }
            public List<Amazon.Mgn.Model.SourceConfiguration> SourceConfiguration { get; set; }
            public Amazon.Mgn.TargetDeployment TargetDeployment { get; set; }
            public System.String TargetNetwork_InboundCidr { get; set; }
            public System.String TargetNetwork_InspectionCidr { get; set; }
            public System.String TargetNetwork_OutboundCidr { get; set; }
            public Amazon.Mgn.TargetNetworkTopology TargetNetwork_Topology { get; set; }
            public System.String TargetS3Configuration_S3Bucket { get; set; }
            public System.String TargetS3Configuration_S3BucketOwner { get; set; }
            public System.Func<Amazon.Mgn.Model.UpdateNetworkMigrationDefinitionResponse, UpdateMGNNetworkMigrationDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
