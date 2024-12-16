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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Creates a contact, which is an end-user who is receiving the email, and adds them
    /// to a contact list.
    /// </summary>
    [Cmdlet("New", "SES2Contact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) CreateContact API operation.", Operation = new[] {"CreateContact"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.CreateContactResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.CreateContactResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.CreateContactResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewSES2ContactCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributesData
        /// <summary>
        /// <para>
        /// <para>The attribute data attached to a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttributesData { get; set; }
        #endregion
        
        #region Parameter ContactListName
        /// <summary>
        /// <para>
        /// <para>The name of the contact list to which the contact should be added.</para>
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
        public System.String ContactListName { get; set; }
        #endregion
        
        #region Parameter EmailAddress
        /// <summary>
        /// <para>
        /// <para>The contact's email address.</para>
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
        public System.String EmailAddress { get; set; }
        #endregion
        
        #region Parameter TopicPreference
        /// <summary>
        /// <para>
        /// <para>The contact's preferences for being opted-in to or opted-out of topics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicPreferences")]
        public Amazon.SimpleEmailV2.Model.TopicPreference[] TopicPreference { get; set; }
        #endregion
        
        #region Parameter UnsubscribeAll
        /// <summary>
        /// <para>
        /// <para>A boolean value status noting if the contact is unsubscribed from all contact list
        /// topics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UnsubscribeAll { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.CreateContactResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactListName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SES2Contact (CreateContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.CreateContactResponse, NewSES2ContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttributesData = this.AttributesData;
            context.ContactListName = this.ContactListName;
            #if MODULAR
            if (this.ContactListName == null && ParameterWasBound(nameof(this.ContactListName)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactListName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailAddress = this.EmailAddress;
            #if MODULAR
            if (this.EmailAddress == null && ParameterWasBound(nameof(this.EmailAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TopicPreference != null)
            {
                context.TopicPreference = new List<Amazon.SimpleEmailV2.Model.TopicPreference>(this.TopicPreference);
            }
            context.UnsubscribeAll = this.UnsubscribeAll;
            
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
            var request = new Amazon.SimpleEmailV2.Model.CreateContactRequest();
            
            if (cmdletContext.AttributesData != null)
            {
                request.AttributesData = cmdletContext.AttributesData;
            }
            if (cmdletContext.ContactListName != null)
            {
                request.ContactListName = cmdletContext.ContactListName;
            }
            if (cmdletContext.EmailAddress != null)
            {
                request.EmailAddress = cmdletContext.EmailAddress;
            }
            if (cmdletContext.TopicPreference != null)
            {
                request.TopicPreferences = cmdletContext.TopicPreference;
            }
            if (cmdletContext.UnsubscribeAll != null)
            {
                request.UnsubscribeAll = cmdletContext.UnsubscribeAll.Value;
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
        
        private Amazon.SimpleEmailV2.Model.CreateContactResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.CreateContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "CreateContact");
            try
            {
                #if DESKTOP
                return client.CreateContact(request);
                #elif CORECLR
                return client.CreateContactAsync(request).GetAwaiter().GetResult();
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
            public System.String AttributesData { get; set; }
            public System.String ContactListName { get; set; }
            public System.String EmailAddress { get; set; }
            public List<Amazon.SimpleEmailV2.Model.TopicPreference> TopicPreference { get; set; }
            public System.Boolean? UnsubscribeAll { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.CreateContactResponse, NewSES2ContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
