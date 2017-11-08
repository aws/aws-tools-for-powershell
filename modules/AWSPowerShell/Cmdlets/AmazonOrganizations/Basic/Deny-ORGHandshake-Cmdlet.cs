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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Declines a handshake request. This sets the handshake state to <code>DECLINED</code>
    /// and effectively deactivates the request.
    /// 
    ///  
    /// <para>
    /// This operation can be called only from the account that received the handshake. The
    /// originator of the handshake can use <a>CancelHandshake</a> instead. The originator
    /// can't reactivate a declined request, but can re-initiate the process with a new handshake
    /// request.
    /// </para><para>
    /// After you decline a handshake, it continues to appear in the results of relevant APIs
    /// for only 30 days. After that it is deleted.
    /// </para>
    /// </summary>
    [Cmdlet("Deny", "ORGHandshake", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.Handshake")]
    [AWSCmdlet("Calls the AWS Organizations DeclineHandshake API operation.", Operation = new[] {"DeclineHandshake"})]
    [AWSCmdletOutput("Amazon.Organizations.Model.Handshake",
        "This cmdlet returns a Handshake object.",
        "The service call response (type Amazon.Organizations.Model.DeclineHandshakeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DenyORGHandshakeCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter HandshakeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the handshake that you want to decline. You can get
        /// the ID from the <a>ListHandshakesForAccount</a> operation.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for handshake ID string
        /// requires "h-" followed by from 8 to 32 lower-case letters or digits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String HandshakeId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("HandshakeId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Deny-ORGHandshake (DeclineHandshake)"))
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
            
            context.HandshakeId = this.HandshakeId;
            
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
            var request = new Amazon.Organizations.Model.DeclineHandshakeRequest();
            
            if (cmdletContext.HandshakeId != null)
            {
                request.HandshakeId = cmdletContext.HandshakeId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Handshake;
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
        
        private Amazon.Organizations.Model.DeclineHandshakeResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.DeclineHandshakeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "DeclineHandshake");
            try
            {
                #if DESKTOP
                return client.DeclineHandshake(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeclineHandshakeAsync(request);
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
            public System.String HandshakeId { get; set; }
        }
        
    }
}
