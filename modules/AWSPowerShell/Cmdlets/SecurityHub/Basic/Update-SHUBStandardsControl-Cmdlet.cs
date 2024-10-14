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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Used to control whether an individual security standard control is enabled or disabled.
    /// </summary>
    [Cmdlet("Update", "SHUBStandardsControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Hub UpdateStandardsControl API operation.", Operation = new[] {"UpdateStandardsControl"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.UpdateStandardsControlResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityHub.Model.UpdateStandardsControlResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityHub.Model.UpdateStandardsControlResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSHUBStandardsControlCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ControlStatus
        /// <summary>
        /// <para>
        /// <para>The updated status of the security standard control.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.ControlStatus")]
        public Amazon.SecurityHub.ControlStatus ControlStatus { get; set; }
        #endregion
        
        #region Parameter DisabledReason
        /// <summary>
        /// <para>
        /// <para>A description of the reason why you are disabling a security standard control. If
        /// you are disabling a control, then this is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisabledReason { get; set; }
        #endregion
        
        #region Parameter StandardsControlArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the security standard control to enable or disable.</para>
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
        public System.String StandardsControlArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.UpdateStandardsControlResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StandardsControlArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StandardsControlArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StandardsControlArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StandardsControlArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHUBStandardsControl (UpdateStandardsControl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.UpdateStandardsControlResponse, UpdateSHUBStandardsControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StandardsControlArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ControlStatus = this.ControlStatus;
            context.DisabledReason = this.DisabledReason;
            context.StandardsControlArn = this.StandardsControlArn;
            #if MODULAR
            if (this.StandardsControlArn == null && ParameterWasBound(nameof(this.StandardsControlArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StandardsControlArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.UpdateStandardsControlRequest();
            
            if (cmdletContext.ControlStatus != null)
            {
                request.ControlStatus = cmdletContext.ControlStatus;
            }
            if (cmdletContext.DisabledReason != null)
            {
                request.DisabledReason = cmdletContext.DisabledReason;
            }
            if (cmdletContext.StandardsControlArn != null)
            {
                request.StandardsControlArn = cmdletContext.StandardsControlArn;
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
        
        private Amazon.SecurityHub.Model.UpdateStandardsControlResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.UpdateStandardsControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "UpdateStandardsControl");
            try
            {
                #if DESKTOP
                return client.UpdateStandardsControl(request);
                #elif CORECLR
                return client.UpdateStandardsControlAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SecurityHub.ControlStatus ControlStatus { get; set; }
            public System.String DisabledReason { get; set; }
            public System.String StandardsControlArn { get; set; }
            public System.Func<Amazon.SecurityHub.Model.UpdateStandardsControlResponse, UpdateSHUBStandardsControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
