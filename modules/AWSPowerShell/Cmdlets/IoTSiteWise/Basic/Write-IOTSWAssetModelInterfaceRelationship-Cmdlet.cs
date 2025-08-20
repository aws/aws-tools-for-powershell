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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Creates or updates an interface relationship between an asset model and an interface
    /// asset model. This operation applies an interface to an asset model.
    /// </summary>
    [Cmdlet("Write", "IOTSWAssetModelInterfaceRelationship", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise PutAssetModelInterfaceRelationship API operation.", Operation = new[] {"PutAssetModelInterfaceRelationship"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipResponse object containing multiple properties."
    )]
    public partial class WriteIOTSWAssetModelInterfaceRelationshipCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset model. This can be either the actual ID in UUID format, or else
        /// externalId: followed by the external ID.</para>
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
        public System.String AssetModelId { get; set; }
        #endregion
        
        #region Parameter PropertyMappingConfiguration_CreateMissingProperty
        /// <summary>
        /// <para>
        /// <para>If true, missing properties from the interface asset model are automatically created
        /// in the asset model where the interface is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PropertyMappingConfiguration_CreateMissingProperty { get; set; }
        #endregion
        
        #region Parameter InterfaceAssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the interface asset model. This can be either the actual ID in UUID format,
        /// or else externalId: followed by the external ID.</para>
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
        public System.String InterfaceAssetModelId { get; set; }
        #endregion
        
        #region Parameter PropertyMappingConfiguration_MatchByPropertyName
        /// <summary>
        /// <para>
        /// <para>If true, properties are matched by name between the interface asset model and the
        /// asset model where the interface is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PropertyMappingConfiguration_MatchByPropertyName { get; set; }
        #endregion
        
        #region Parameter PropertyMappingConfiguration_Override
        /// <summary>
        /// <para>
        /// <para>A list of specific property mappings that override the automatic mapping by name when
        /// an interface is applied to an asset model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropertyMappingConfiguration_Overrides")]
        public Amazon.IoTSiteWise.Model.PropertyMapping[] PropertyMappingConfiguration_Override { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssetModelId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssetModelId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssetModelId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssetModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-IOTSWAssetModelInterfaceRelationship (PutAssetModelInterfaceRelationship)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipResponse, WriteIOTSWAssetModelInterfaceRelationshipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssetModelId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssetModelId = this.AssetModelId;
            #if MODULAR
            if (this.AssetModelId == null && ParameterWasBound(nameof(this.AssetModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.InterfaceAssetModelId = this.InterfaceAssetModelId;
            #if MODULAR
            if (this.InterfaceAssetModelId == null && ParameterWasBound(nameof(this.InterfaceAssetModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter InterfaceAssetModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PropertyMappingConfiguration_CreateMissingProperty = this.PropertyMappingConfiguration_CreateMissingProperty;
            context.PropertyMappingConfiguration_MatchByPropertyName = this.PropertyMappingConfiguration_MatchByPropertyName;
            if (this.PropertyMappingConfiguration_Override != null)
            {
                context.PropertyMappingConfiguration_Override = new List<Amazon.IoTSiteWise.Model.PropertyMapping>(this.PropertyMappingConfiguration_Override);
            }
            
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
            var request = new Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipRequest();
            
            if (cmdletContext.AssetModelId != null)
            {
                request.AssetModelId = cmdletContext.AssetModelId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InterfaceAssetModelId != null)
            {
                request.InterfaceAssetModelId = cmdletContext.InterfaceAssetModelId;
            }
            
             // populate PropertyMappingConfiguration
            request.PropertyMappingConfiguration = new Amazon.IoTSiteWise.Model.PropertyMappingConfiguration();
            System.Boolean? requestPropertyMappingConfiguration_propertyMappingConfiguration_CreateMissingProperty = null;
            if (cmdletContext.PropertyMappingConfiguration_CreateMissingProperty != null)
            {
                requestPropertyMappingConfiguration_propertyMappingConfiguration_CreateMissingProperty = cmdletContext.PropertyMappingConfiguration_CreateMissingProperty.Value;
            }
            if (requestPropertyMappingConfiguration_propertyMappingConfiguration_CreateMissingProperty != null)
            {
                request.PropertyMappingConfiguration.CreateMissingProperty = requestPropertyMappingConfiguration_propertyMappingConfiguration_CreateMissingProperty.Value;
            }
            System.Boolean? requestPropertyMappingConfiguration_propertyMappingConfiguration_MatchByPropertyName = null;
            if (cmdletContext.PropertyMappingConfiguration_MatchByPropertyName != null)
            {
                requestPropertyMappingConfiguration_propertyMappingConfiguration_MatchByPropertyName = cmdletContext.PropertyMappingConfiguration_MatchByPropertyName.Value;
            }
            if (requestPropertyMappingConfiguration_propertyMappingConfiguration_MatchByPropertyName != null)
            {
                request.PropertyMappingConfiguration.MatchByPropertyName = requestPropertyMappingConfiguration_propertyMappingConfiguration_MatchByPropertyName.Value;
            }
            List<Amazon.IoTSiteWise.Model.PropertyMapping> requestPropertyMappingConfiguration_propertyMappingConfiguration_Override = null;
            if (cmdletContext.PropertyMappingConfiguration_Override != null)
            {
                requestPropertyMappingConfiguration_propertyMappingConfiguration_Override = cmdletContext.PropertyMappingConfiguration_Override;
            }
            if (requestPropertyMappingConfiguration_propertyMappingConfiguration_Override != null)
            {
                request.PropertyMappingConfiguration.Overrides = requestPropertyMappingConfiguration_propertyMappingConfiguration_Override;
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
        
        private Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "PutAssetModelInterfaceRelationship");
            try
            {
                #if DESKTOP
                return client.PutAssetModelInterfaceRelationship(request);
                #elif CORECLR
                return client.PutAssetModelInterfaceRelationshipAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetModelId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String InterfaceAssetModelId { get; set; }
            public System.Boolean? PropertyMappingConfiguration_CreateMissingProperty { get; set; }
            public System.Boolean? PropertyMappingConfiguration_MatchByPropertyName { get; set; }
            public List<Amazon.IoTSiteWise.Model.PropertyMapping> PropertyMappingConfiguration_Override { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.PutAssetModelInterfaceRelationshipResponse, WriteIOTSWAssetModelInterfaceRelationshipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
