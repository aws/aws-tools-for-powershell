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
using Amazon.LicenseManagerUserSubscriptions;
using Amazon.LicenseManagerUserSubscriptions.Model;

namespace Amazon.PowerShell.Cmdlets.LMUS
{
    /// <summary>
    /// Deletes a <c>LicenseServerEndpoint</c> resource.
    /// </summary>
    [Cmdlet("Remove", "LMUSLicenseServerEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.LicenseManagerUserSubscriptions.Model.LicenseServerEndpoint")]
    [AWSCmdlet("Calls the AWS License Manager User Subscription DeleteLicenseServerEndpoint API operation.", Operation = new[] {"DeleteLicenseServerEndpoint"}, SelectReturnType = typeof(Amazon.LicenseManagerUserSubscriptions.Model.DeleteLicenseServerEndpointResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerUserSubscriptions.Model.LicenseServerEndpoint or Amazon.LicenseManagerUserSubscriptions.Model.DeleteLicenseServerEndpointResponse",
        "This cmdlet returns an Amazon.LicenseManagerUserSubscriptions.Model.LicenseServerEndpoint object.",
        "The service call response (type Amazon.LicenseManagerUserSubscriptions.Model.DeleteLicenseServerEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveLMUSLicenseServerEndpointCmdlet : AmazonLicenseManagerUserSubscriptionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LicenseServerEndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that identifies the <c>LicenseServerEndpoint</c> resource
        /// to delete.</para>
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
        public System.String LicenseServerEndpointArn { get; set; }
        #endregion
        
        #region Parameter ServerType
        /// <summary>
        /// <para>
        /// <para>The type of License Server that the delete request refers to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LicenseManagerUserSubscriptions.ServerType")]
        public Amazon.LicenseManagerUserSubscriptions.ServerType ServerType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LicenseServerEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerUserSubscriptions.Model.DeleteLicenseServerEndpointResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerUserSubscriptions.Model.DeleteLicenseServerEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LicenseServerEndpoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LicenseServerEndpointArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LicenseServerEndpointArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LicenseServerEndpointArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LicenseServerEndpointArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-LMUSLicenseServerEndpoint (DeleteLicenseServerEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerUserSubscriptions.Model.DeleteLicenseServerEndpointResponse, RemoveLMUSLicenseServerEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LicenseServerEndpointArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LicenseServerEndpointArn = this.LicenseServerEndpointArn;
            #if MODULAR
            if (this.LicenseServerEndpointArn == null && ParameterWasBound(nameof(this.LicenseServerEndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseServerEndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerType = this.ServerType;
            #if MODULAR
            if (this.ServerType == null && ParameterWasBound(nameof(this.ServerType)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LicenseManagerUserSubscriptions.Model.DeleteLicenseServerEndpointRequest();
            
            if (cmdletContext.LicenseServerEndpointArn != null)
            {
                request.LicenseServerEndpointArn = cmdletContext.LicenseServerEndpointArn;
            }
            if (cmdletContext.ServerType != null)
            {
                request.ServerType = cmdletContext.ServerType;
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
        
        private Amazon.LicenseManagerUserSubscriptions.Model.DeleteLicenseServerEndpointResponse CallAWSServiceOperation(IAmazonLicenseManagerUserSubscriptions client, Amazon.LicenseManagerUserSubscriptions.Model.DeleteLicenseServerEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager User Subscription", "DeleteLicenseServerEndpoint");
            try
            {
                #if DESKTOP
                return client.DeleteLicenseServerEndpoint(request);
                #elif CORECLR
                return client.DeleteLicenseServerEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String LicenseServerEndpointArn { get; set; }
            public Amazon.LicenseManagerUserSubscriptions.ServerType ServerType { get; set; }
            public System.Func<Amazon.LicenseManagerUserSubscriptions.Model.DeleteLicenseServerEndpointResponse, RemoveLMUSLicenseServerEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LicenseServerEndpoint;
        }
        
    }
}
