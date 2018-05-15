/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.ALXB
{
    /// <summary>
    /// Creates a contact with the specified details.
    /// </summary>
    [Cmdlet("New", "ALXBContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Alexa For Business CreateContact API operation.", Operation = new[] {"CreateContact"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.AlexaForBusiness.Model.CreateContactResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewALXBContactCmdlet : AmazonAlexaForBusinessClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, user-specified identifier for this request that ensures idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The name of the contact to display on the console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter FirstName
        /// <summary>
        /// <para>
        /// <para>The first name of the contact that is used to call the contact on the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FirstName { get; set; }
        #endregion
        
        #region Parameter LastName
        /// <summary>
        /// <para>
        /// <para>The last name of the contact that is used to call the contact on the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LastName { get; set; }
        #endregion
        
        #region Parameter PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact in E.164 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PhoneNumber { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DisplayName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ALXBContact (CreateContact)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientRequestToken = this.ClientRequestToken;
            context.DisplayName = this.DisplayName;
            context.FirstName = this.FirstName;
            context.LastName = this.LastName;
            context.PhoneNumber = this.PhoneNumber;
            
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
            var request = new Amazon.AlexaForBusiness.Model.CreateContactRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.FirstName != null)
            {
                request.FirstName = cmdletContext.FirstName;
            }
            if (cmdletContext.LastName != null)
            {
                request.LastName = cmdletContext.LastName;
            }
            if (cmdletContext.PhoneNumber != null)
            {
                request.PhoneNumber = cmdletContext.PhoneNumber;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ContactArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.AlexaForBusiness.Model.CreateContactResponse CallAWSServiceOperation(IAmazonAlexaForBusiness client, Amazon.AlexaForBusiness.Model.CreateContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Alexa For Business", "CreateContact");
            try
            {
                #if DESKTOP
                return client.CreateContact(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateContactAsync(request);
                return task.Result;
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
            public System.String ClientRequestToken { get; set; }
            public System.String DisplayName { get; set; }
            public System.String FirstName { get; set; }
            public System.String LastName { get; set; }
            public System.String PhoneNumber { get; set; }
        }
        
    }
}
