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
    /// Retrieves information about a previously requested handshake. The handshake ID comes
    /// from the response to the original <a>InviteAccountToOrganization</a> operation that
    /// generated the handshake.
    /// 
    ///  
    /// <para>
    /// You can access handshakes that are ACCEPTED, DECLINED, or CANCELED for only 30 days
    /// after they change to that state. They are then deleted and no longer accessible.
    /// </para><para>
    /// This operation can be called from any account in the organization.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ORGHandshake")]
    [OutputType("Amazon.Organizations.Model.Handshake")]
    [AWSCmdlet("Calls the AWS Organizations DescribeHandshake API operation.", Operation = new[] {"DescribeHandshake"})]
    [AWSCmdletOutput("Amazon.Organizations.Model.Handshake",
        "This cmdlet returns a Handshake object.",
        "The service call response (type Amazon.Organizations.Model.DescribeHandshakeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetORGHandshakeCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter HandshakeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the handshake that you want information about. You can
        /// get the ID from the original call to <a>InviteAccountToOrganization</a>, or from a
        /// call to <a>ListHandshakesForAccount</a> or <a>ListHandshakesForOrganization</a>.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for handshake ID string
        /// requires "h-" followed by from 8 to 32 lower-case letters or digits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String HandshakeId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
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
            var request = new Amazon.Organizations.Model.DescribeHandshakeRequest();
            
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
        
        private Amazon.Organizations.Model.DescribeHandshakeResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.DescribeHandshakeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "DescribeHandshake");
            try
            {
                #if DESKTOP
                return client.DescribeHandshake(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeHandshakeAsync(request);
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
