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
using Amazon.DataZone;
using Amazon.DataZone.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Creates a Amazon DataZone blueprint.
    /// </summary>
    [Cmdlet("New", "DZEnvironmentBlueprint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.CreateEnvironmentBlueprintResponse")]
    [AWSCmdlet("Calls the Amazon DataZone CreateEnvironmentBlueprint API operation.", Operation = new[] {"CreateEnvironmentBlueprint"}, SelectReturnType = typeof(Amazon.DataZone.Model.CreateEnvironmentBlueprintResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.CreateEnvironmentBlueprintResponse",
        "This cmdlet returns an Amazon.DataZone.Model.CreateEnvironmentBlueprintResponse object containing multiple properties."
    )]
    public partial class NewDZEnvironmentBlueprintCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the Amazon DataZone blueprint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the domain in which this blueprint is created.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of this Amazon DataZone blueprint.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter CloudFormation_TemplateUrl
        /// <summary>
        /// <para>
        /// <para>The template URL of the cloud formation provisioning properties of the environment
        /// blueprint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisioningProperties_CloudFormation_TemplateUrl")]
        public System.String CloudFormation_TemplateUrl { get; set; }
        #endregion
        
        #region Parameter UserParameter
        /// <summary>
        /// <para>
        /// <para>The user parameters of this Amazon DataZone blueprint.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserParameters")]
        public Amazon.DataZone.Model.CustomParameter[] UserParameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.CreateEnvironmentBlueprintResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.CreateEnvironmentBlueprintResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DZEnvironmentBlueprint (CreateEnvironmentBlueprint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.CreateEnvironmentBlueprintResponse, NewDZEnvironmentBlueprintCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudFormation_TemplateUrl = this.CloudFormation_TemplateUrl;
            if (this.UserParameter != null)
            {
                context.UserParameter = new List<Amazon.DataZone.Model.CustomParameter>(this.UserParameter);
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
            var request = new Amazon.DataZone.Model.CreateEnvironmentBlueprintRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ProvisioningProperties
            var requestProvisioningPropertiesIsNull = true;
            request.ProvisioningProperties = new Amazon.DataZone.Model.ProvisioningProperties();
            Amazon.DataZone.Model.CloudFormationProperties requestProvisioningProperties_provisioningProperties_CloudFormation = null;
            
             // populate CloudFormation
            var requestProvisioningProperties_provisioningProperties_CloudFormationIsNull = true;
            requestProvisioningProperties_provisioningProperties_CloudFormation = new Amazon.DataZone.Model.CloudFormationProperties();
            System.String requestProvisioningProperties_provisioningProperties_CloudFormation_cloudFormation_TemplateUrl = null;
            if (cmdletContext.CloudFormation_TemplateUrl != null)
            {
                requestProvisioningProperties_provisioningProperties_CloudFormation_cloudFormation_TemplateUrl = cmdletContext.CloudFormation_TemplateUrl;
            }
            if (requestProvisioningProperties_provisioningProperties_CloudFormation_cloudFormation_TemplateUrl != null)
            {
                requestProvisioningProperties_provisioningProperties_CloudFormation.TemplateUrl = requestProvisioningProperties_provisioningProperties_CloudFormation_cloudFormation_TemplateUrl;
                requestProvisioningProperties_provisioningProperties_CloudFormationIsNull = false;
            }
             // determine if requestProvisioningProperties_provisioningProperties_CloudFormation should be set to null
            if (requestProvisioningProperties_provisioningProperties_CloudFormationIsNull)
            {
                requestProvisioningProperties_provisioningProperties_CloudFormation = null;
            }
            if (requestProvisioningProperties_provisioningProperties_CloudFormation != null)
            {
                request.ProvisioningProperties.CloudFormation = requestProvisioningProperties_provisioningProperties_CloudFormation;
                requestProvisioningPropertiesIsNull = false;
            }
             // determine if request.ProvisioningProperties should be set to null
            if (requestProvisioningPropertiesIsNull)
            {
                request.ProvisioningProperties = null;
            }
            if (cmdletContext.UserParameter != null)
            {
                request.UserParameters = cmdletContext.UserParameter;
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
        
        private Amazon.DataZone.Model.CreateEnvironmentBlueprintResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.CreateEnvironmentBlueprintRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "CreateEnvironmentBlueprint");
            try
            {
                return client.CreateEnvironmentBlueprintAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.String CloudFormation_TemplateUrl { get; set; }
            public List<Amazon.DataZone.Model.CustomParameter> UserParameter { get; set; }
            public System.Func<Amazon.DataZone.Model.CreateEnvironmentBlueprintResponse, NewDZEnvironmentBlueprintCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
