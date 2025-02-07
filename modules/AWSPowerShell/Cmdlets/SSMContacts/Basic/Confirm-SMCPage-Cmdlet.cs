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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Used to acknowledge an engagement to a contact channel during an incident.
    /// </summary>
    [Cmdlet("Confirm", "SMCPage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager Contacts AcceptPage API operation.", Operation = new[] {"AcceptPage"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.AcceptPageResponse))]
    [AWSCmdletOutput("None or Amazon.SSMContacts.Model.AcceptPageResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSMContacts.Model.AcceptPageResponse) be returned by specifying '-Select *'."
    )]
    public partial class ConfirmSMCPageCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptCode
        /// <summary>
        /// <para>
        /// <para>A 6-digit code used to acknowledge the page.</para>
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
        public System.String AcceptCode { get; set; }
        #endregion
        
        #region Parameter AcceptCodeValidation
        /// <summary>
        /// <para>
        /// <para>An optional field that Incident Manager uses to <c>ENFORCE</c><c>AcceptCode</c> validation
        /// when acknowledging an page. Acknowledgement can occur by replying to a page, or when
        /// entering the AcceptCode in the console. Enforcing AcceptCode validation causes Incident
        /// Manager to verify that the code entered by the user matches the code sent by Incident
        /// Manager with the page.</para><para>Incident Manager can also <c>IGNORE</c><c>AcceptCode</c> validation. Ignoring <c>AcceptCode</c>
        /// validation causes Incident Manager to accept any value entered for the <c>AcceptCode</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SSMContacts.AcceptCodeValidation")]
        public Amazon.SSMContacts.AcceptCodeValidation AcceptCodeValidation { get; set; }
        #endregion
        
        #region Parameter AcceptType
        /// <summary>
        /// <para>
        /// <para>The type indicates if the page was <c>DELIVERED</c> or <c>READ</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SSMContacts.AcceptType")]
        public Amazon.SSMContacts.AcceptType AcceptType { get; set; }
        #endregion
        
        #region Parameter ContactChannelId
        /// <summary>
        /// <para>
        /// <para>The ARN of the contact channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactChannelId { get; set; }
        #endregion
        
        #region Parameter Note
        /// <summary>
        /// <para>
        /// <para>Information provided by the user when the user acknowledges the page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Note { get; set; }
        #endregion
        
        #region Parameter PageId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the engagement to a contact channel.</para>
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
        public System.String PageId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.AcceptPageResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-SMCPage (AcceptPage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.AcceptPageResponse, ConfirmSMCPageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptCode = this.AcceptCode;
            #if MODULAR
            if (this.AcceptCode == null && ParameterWasBound(nameof(this.AcceptCode)))
            {
                WriteWarning("You are passing $null as a value for parameter AcceptCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AcceptCodeValidation = this.AcceptCodeValidation;
            context.AcceptType = this.AcceptType;
            #if MODULAR
            if (this.AcceptType == null && ParameterWasBound(nameof(this.AcceptType)))
            {
                WriteWarning("You are passing $null as a value for parameter AcceptType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactChannelId = this.ContactChannelId;
            context.Note = this.Note;
            context.PageId = this.PageId;
            #if MODULAR
            if (this.PageId == null && ParameterWasBound(nameof(this.PageId)))
            {
                WriteWarning("You are passing $null as a value for parameter PageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSMContacts.Model.AcceptPageRequest();
            
            if (cmdletContext.AcceptCode != null)
            {
                request.AcceptCode = cmdletContext.AcceptCode;
            }
            if (cmdletContext.AcceptCodeValidation != null)
            {
                request.AcceptCodeValidation = cmdletContext.AcceptCodeValidation;
            }
            if (cmdletContext.AcceptType != null)
            {
                request.AcceptType = cmdletContext.AcceptType;
            }
            if (cmdletContext.ContactChannelId != null)
            {
                request.ContactChannelId = cmdletContext.ContactChannelId;
            }
            if (cmdletContext.Note != null)
            {
                request.Note = cmdletContext.Note;
            }
            if (cmdletContext.PageId != null)
            {
                request.PageId = cmdletContext.PageId;
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
        
        private Amazon.SSMContacts.Model.AcceptPageResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.AcceptPageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager Contacts", "AcceptPage");
            try
            {
                #if DESKTOP
                return client.AcceptPage(request);
                #elif CORECLR
                return client.AcceptPageAsync(request).GetAwaiter().GetResult();
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
            public System.String AcceptCode { get; set; }
            public Amazon.SSMContacts.AcceptCodeValidation AcceptCodeValidation { get; set; }
            public Amazon.SSMContacts.AcceptType AcceptType { get; set; }
            public System.String ContactChannelId { get; set; }
            public System.String Note { get; set; }
            public System.String PageId { get; set; }
            public System.Func<Amazon.SSMContacts.Model.AcceptPageResponse, ConfirmSMCPageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
