/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Creates or updates an app.
    /// </summary>
    [Cmdlet("New", "PINApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.ApplicationResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateApp API operation.", Operation = new[] {"CreateApp"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.ApplicationResponse",
        "This cmdlet returns a ApplicationResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateAppResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINAppCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter CreateApplicationRequest_Name
        /// <summary>
        /// <para>
        /// The display name of the application. Used in the
        /// Amazon Pinpoint console.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CreateApplicationRequest_Name { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CreateApplicationRequest_Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINApp (CreateApp)"))
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
            
            context.CreateApplicationRequest_Name = this.CreateApplicationRequest_Name;
            
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
            var request = new Amazon.Pinpoint.Model.CreateAppRequest();
            
            
             // populate CreateApplicationRequest
            bool requestCreateApplicationRequestIsNull = true;
            request.CreateApplicationRequest = new Amazon.Pinpoint.Model.CreateApplicationRequest();
            System.String requestCreateApplicationRequest_createApplicationRequest_Name = null;
            if (cmdletContext.CreateApplicationRequest_Name != null)
            {
                requestCreateApplicationRequest_createApplicationRequest_Name = cmdletContext.CreateApplicationRequest_Name;
            }
            if (requestCreateApplicationRequest_createApplicationRequest_Name != null)
            {
                request.CreateApplicationRequest.Name = requestCreateApplicationRequest_createApplicationRequest_Name;
                requestCreateApplicationRequestIsNull = false;
            }
             // determine if request.CreateApplicationRequest should be set to null
            if (requestCreateApplicationRequestIsNull)
            {
                request.CreateApplicationRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ApplicationResponse;
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
        
        private Amazon.Pinpoint.Model.CreateAppResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateApp");
            try
            {
                #if DESKTOP
                return client.CreateApp(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateAppAsync(request);
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
            public System.String CreateApplicationRequest_Name { get; set; }
        }
        
    }
}
