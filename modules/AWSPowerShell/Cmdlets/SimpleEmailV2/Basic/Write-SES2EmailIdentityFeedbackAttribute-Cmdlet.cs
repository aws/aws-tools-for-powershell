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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Used to enable or disable feedback forwarding for an identity. This setting determines
    /// what happens when an identity is used to send an email that results in a bounce or
    /// complaint event.
    /// 
    ///  
    /// <para>
    /// If the value is <c>true</c>, you receive email notifications when bounce or complaint
    /// events occur. These notifications are sent to the address that you specified in the
    /// <c>Return-Path</c> header of the original email.
    /// </para><para>
    /// You're required to have a method of tracking bounces and complaints. If you haven't
    /// set up another mechanism for receiving bounce or complaint notifications (for example,
    /// by setting up an event destination), you receive an email notification when these
    /// events occur (even if this setting is disabled).
    /// </para>
    /// </summary>
    [Cmdlet("Write", "SES2EmailIdentityFeedbackAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) PutEmailIdentityFeedbackAttributes API operation.", Operation = new[] {"PutEmailIdentityFeedbackAttributes"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.PutEmailIdentityFeedbackAttributesResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.PutEmailIdentityFeedbackAttributesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.PutEmailIdentityFeedbackAttributesResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSES2EmailIdentityFeedbackAttributeCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EmailForwardingEnabled
        /// <summary>
        /// <para>
        /// <para>Sets the feedback forwarding configuration for the identity.</para><para>If the value is <c>true</c>, you receive email notifications when bounce or complaint
        /// events occur. These notifications are sent to the address that you specified in the
        /// <c>Return-Path</c> header of the original email.</para><para>You're required to have a method of tracking bounces and complaints. If you haven't
        /// set up another mechanism for receiving bounce or complaint notifications (for example,
        /// by setting up an event destination), you receive an email notification when these
        /// events occur (even if this setting is disabled).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EmailForwardingEnabled { get; set; }
        #endregion
        
        #region Parameter EmailIdentity
        /// <summary>
        /// <para>
        /// <para>The email identity.</para>
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
        public System.String EmailIdentity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.PutEmailIdentityFeedbackAttributesResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EmailIdentity), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SES2EmailIdentityFeedbackAttribute (PutEmailIdentityFeedbackAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.PutEmailIdentityFeedbackAttributesResponse, WriteSES2EmailIdentityFeedbackAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EmailForwardingEnabled = this.EmailForwardingEnabled;
            context.EmailIdentity = this.EmailIdentity;
            #if MODULAR
            if (this.EmailIdentity == null && ParameterWasBound(nameof(this.EmailIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmailV2.Model.PutEmailIdentityFeedbackAttributesRequest();
            
            if (cmdletContext.EmailForwardingEnabled != null)
            {
                request.EmailForwardingEnabled = cmdletContext.EmailForwardingEnabled.Value;
            }
            if (cmdletContext.EmailIdentity != null)
            {
                request.EmailIdentity = cmdletContext.EmailIdentity;
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
        
        private Amazon.SimpleEmailV2.Model.PutEmailIdentityFeedbackAttributesResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.PutEmailIdentityFeedbackAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "PutEmailIdentityFeedbackAttributes");
            try
            {
                #if DESKTOP
                return client.PutEmailIdentityFeedbackAttributes(request);
                #elif CORECLR
                return client.PutEmailIdentityFeedbackAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? EmailForwardingEnabled { get; set; }
            public System.String EmailIdentity { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.PutEmailIdentityFeedbackAttributesResponse, WriteSES2EmailIdentityFeedbackAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
