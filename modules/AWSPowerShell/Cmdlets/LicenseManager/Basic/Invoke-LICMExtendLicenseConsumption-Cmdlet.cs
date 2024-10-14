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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Extends the expiration date for license consumption.
    /// </summary>
    [Cmdlet("Invoke", "LICMExtendLicenseConsumption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LicenseManager.Model.ExtendLicenseConsumptionResponse")]
    [AWSCmdlet("Calls the AWS License Manager ExtendLicenseConsumption API operation.", Operation = new[] {"ExtendLicenseConsumption"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.ExtendLicenseConsumptionResponse))]
    [AWSCmdletOutput("Amazon.LicenseManager.Model.ExtendLicenseConsumptionResponse",
        "This cmdlet returns an Amazon.LicenseManager.Model.ExtendLicenseConsumptionResponse object containing multiple properties."
    )]
    public partial class InvokeLICMExtendLicenseConsumptionCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request. Provides an error response if you do not have the required permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter LicenseConsumptionToken
        /// <summary>
        /// <para>
        /// <para>License consumption token.</para>
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
        public System.String LicenseConsumptionToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.ExtendLicenseConsumptionResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.ExtendLicenseConsumptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LicenseConsumptionToken parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LicenseConsumptionToken' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LicenseConsumptionToken' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LicenseConsumptionToken), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-LICMExtendLicenseConsumption (ExtendLicenseConsumption)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.ExtendLicenseConsumptionResponse, InvokeLICMExtendLicenseConsumptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LicenseConsumptionToken;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DryRun = this.DryRun;
            context.LicenseConsumptionToken = this.LicenseConsumptionToken;
            #if MODULAR
            if (this.LicenseConsumptionToken == null && ParameterWasBound(nameof(this.LicenseConsumptionToken)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseConsumptionToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LicenseManager.Model.ExtendLicenseConsumptionRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.LicenseConsumptionToken != null)
            {
                request.LicenseConsumptionToken = cmdletContext.LicenseConsumptionToken;
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
        
        private Amazon.LicenseManager.Model.ExtendLicenseConsumptionResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.ExtendLicenseConsumptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "ExtendLicenseConsumption");
            try
            {
                #if DESKTOP
                return client.ExtendLicenseConsumption(request);
                #elif CORECLR
                return client.ExtendLicenseConsumptionAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String LicenseConsumptionToken { get; set; }
            public System.Func<Amazon.LicenseManager.Model.ExtendLicenseConsumptionResponse, InvokeLICMExtendLicenseConsumptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
