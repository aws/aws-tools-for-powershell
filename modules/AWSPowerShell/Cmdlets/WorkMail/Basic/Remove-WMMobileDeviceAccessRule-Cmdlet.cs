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
using Amazon.WorkMail;
using Amazon.WorkMail.Model;

namespace Amazon.PowerShell.Cmdlets.WM
{
    /// <summary>
    /// Deletes a mobile device access rule for the specified WorkMail organization.
    /// 
    ///  <note><para>
    /// Deleting already deleted and non-existing rules does not produce an error. In those
    /// cases, the service sends back an HTTP 200 response with an empty HTTP body.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "WMMobileDeviceAccessRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkMail DeleteMobileDeviceAccessRule API operation.", Operation = new[] {"DeleteMobileDeviceAccessRule"}, SelectReturnType = typeof(Amazon.WorkMail.Model.DeleteMobileDeviceAccessRuleResponse))]
    [AWSCmdletOutput("None or Amazon.WorkMail.Model.DeleteMobileDeviceAccessRuleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkMail.Model.DeleteMobileDeviceAccessRuleResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveWMMobileDeviceAccessRuleCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MobileDeviceAccessRuleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the rule to be deleted.</para>
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
        public System.String MobileDeviceAccessRuleId { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The WorkMail organization under which the rule will be deleted.</para>
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
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.DeleteMobileDeviceAccessRuleResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MobileDeviceAccessRuleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-WMMobileDeviceAccessRule (DeleteMobileDeviceAccessRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.DeleteMobileDeviceAccessRuleResponse, RemoveWMMobileDeviceAccessRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MobileDeviceAccessRuleId = this.MobileDeviceAccessRuleId;
            #if MODULAR
            if (this.MobileDeviceAccessRuleId == null && ParameterWasBound(nameof(this.MobileDeviceAccessRuleId)))
            {
                WriteWarning("You are passing $null as a value for parameter MobileDeviceAccessRuleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationId = this.OrganizationId;
            #if MODULAR
            if (this.OrganizationId == null && ParameterWasBound(nameof(this.OrganizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkMail.Model.DeleteMobileDeviceAccessRuleRequest();
            
            if (cmdletContext.MobileDeviceAccessRuleId != null)
            {
                request.MobileDeviceAccessRuleId = cmdletContext.MobileDeviceAccessRuleId;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
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
        
        private Amazon.WorkMail.Model.DeleteMobileDeviceAccessRuleResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.DeleteMobileDeviceAccessRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "DeleteMobileDeviceAccessRule");
            try
            {
                return client.DeleteMobileDeviceAccessRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MobileDeviceAccessRuleId { get; set; }
            public System.String OrganizationId { get; set; }
            public System.Func<Amazon.WorkMail.Model.DeleteMobileDeviceAccessRuleResponse, RemoveWMMobileDeviceAccessRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
