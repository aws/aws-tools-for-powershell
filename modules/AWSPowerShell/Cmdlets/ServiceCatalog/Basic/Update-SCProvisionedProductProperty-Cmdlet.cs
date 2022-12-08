/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Requests updates to the properties of the specified provisioned product.
    /// </summary>
    [Cmdlet("Update", "SCProvisionedProductProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesResponse")]
    [AWSCmdlet("Calls the AWS Service Catalog UpdateProvisionedProductProperties API operation.", Operation = new[] {"UpdateProvisionedProductProperties"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesResponse",
        "This cmdlet returns an Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSCProvisionedProductPropertyCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><code>en</code> - English (default)</para></li><li><para><code>jp</code> - Japanese</para></li><li><para><code>zh</code> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token that uniquely identifies the provisioning product update request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter ProvisionedProductId
        /// <summary>
        /// <para>
        /// <para>The identifier of the provisioned product.</para>
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
        public System.String ProvisionedProductId { get; set; }
        #endregion
        
        #region Parameter ProvisionedProductProperty
        /// <summary>
        /// <para>
        /// <para>A map that contains the provisioned product properties to be updated.</para><para>The <code>LAUNCH_ROLE</code> key accepts role ARNs. This key allows an administrator
        /// to call <code>UpdateProvisionedProductProperties</code> to update the launch role
        /// that is associated with a provisioned product. This role is used when an end user
        /// calls a provisioning operation such as <code>UpdateProvisionedProduct</code>, <code>TerminateProvisionedProduct</code>,
        /// or <code>ExecuteProvisionedProductServiceAction</code>. Only a role ARN is valid.
        /// A user ARN is invalid. </para><para>The <code>OWNER</code> key accepts IAM user ARNs, IAM role ARNs, and STS assumed-role
        /// ARNs. The owner is the user that has permission to see, update, terminate, and execute
        /// service actions in the provisioned product.</para><para>The administrator can change the owner of a provisioned product to another IAM or
        /// STS entity within the same account. Both end user owners and administrators can see
        /// ownership history of the provisioned product using the <code>ListRecordHistory</code>
        /// API. The new owner can describe all past records for the provisioned product using
        /// the <code>DescribeRecord</code> API. The previous owner can no longer use <code>DescribeRecord</code>,
        /// but can still see the product's history from when he was an owner using <code>ListRecordHistory</code>.</para><para>If a provisioned product ownership is assigned to an end user, they can see and perform
        /// any action through the API or Service Catalog console such as update, terminate, and
        /// execute service actions. If an end user provisions a product and the owner is updated
        /// to someone else, they will no longer be able to see or perform any actions through
        /// API or the Service Catalog console on that provisioned product.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ProvisionedProductProperties")]
        public System.Collections.Hashtable ProvisionedProductProperty { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProvisionedProductId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProvisionedProductId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProvisionedProductId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProvisionedProductId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SCProvisionedProductProperty (UpdateProvisionedProductProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesResponse, UpdateSCProvisionedProductPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProvisionedProductId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceptLanguage = this.AcceptLanguage;
            context.IdempotencyToken = this.IdempotencyToken;
            context.ProvisionedProductId = this.ProvisionedProductId;
            #if MODULAR
            if (this.ProvisionedProductId == null && ParameterWasBound(nameof(this.ProvisionedProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProvisionedProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ProvisionedProductProperty != null)
            {
                context.ProvisionedProductProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ProvisionedProductProperty.Keys)
                {
                    context.ProvisionedProductProperty.Add((String)hashKey, (String)(this.ProvisionedProductProperty[hashKey]));
                }
            }
            #if MODULAR
            if (this.ProvisionedProductProperty == null && ParameterWasBound(nameof(this.ProvisionedProductProperty)))
            {
                WriteWarning("You are passing $null as a value for parameter ProvisionedProductProperty which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.ProvisionedProductId != null)
            {
                request.ProvisionedProductId = cmdletContext.ProvisionedProductId;
            }
            if (cmdletContext.ProvisionedProductProperty != null)
            {
                request.ProvisionedProductProperties = cmdletContext.ProvisionedProductProperty;
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
        
        private Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "UpdateProvisionedProductProperties");
            try
            {
                #if DESKTOP
                return client.UpdateProvisionedProductProperties(request);
                #elif CORECLR
                return client.UpdateProvisionedProductPropertiesAsync(request).GetAwaiter().GetResult();
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
            public System.String AcceptLanguage { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String ProvisionedProductId { get; set; }
            public Dictionary<System.String, System.String> ProvisionedProductProperty { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.UpdateProvisionedProductPropertiesResponse, UpdateSCProvisionedProductPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
