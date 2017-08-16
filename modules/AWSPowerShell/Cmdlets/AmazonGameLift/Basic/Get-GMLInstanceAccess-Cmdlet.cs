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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Requests remote access to a fleet instance. Remote access is useful for debugging,
    /// gathering benchmarking data, or watching activity in real time. 
    /// 
    ///  
    /// <para>
    /// Access requires credentials that match the operating system of the instance. For a
    /// Windows instance, Amazon GameLift returns a user name and password as strings for
    /// use with a Windows Remote Desktop client. For a Linux instance, Amazon GameLift returns
    /// a user name and RSA private key, also as strings, for use with an SSH client. The
    /// private key must be saved in the proper format to a <code>.pem</code> file before
    /// using. If you're making this request using the AWS CLI, saving the secret can be handled
    /// as part of the GetInstanceAccess request. (See the example later in this topic). For
    /// more information on remote access, see <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-remote-access.html">Remotely
    /// Accessing an Instance</a>.
    /// </para><para>
    /// To request access to a specific instance, specify the IDs of the instance and the
    /// fleet it belongs to. If successful, an <a>InstanceAccess</a> object is returned containing
    /// the instance's IP address and a set of credentials.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "GMLInstanceAccess")]
    [OutputType("Amazon.GameLift.Model.InstanceAccess")]
    [AWSCmdlet("Invokes the GetInstanceAccess operation against Amazon GameLift Service.", Operation = new[] {"GetInstanceAccess"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.InstanceAccess",
        "This cmdlet returns a InstanceAccess object.",
        "The service call response (type Amazon.GameLift.Model.GetInstanceAccessResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGMLInstanceAccessCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet that contains the instance you want access to. The fleet
        /// can be in any of the following statuses: <code>ACTIVATING</code>, <code>ACTIVE</code>,
        /// or <code>ERROR</code>. Fleets with an <code>ERROR</code> status may be accessible
        /// for a short time before they are deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for an instance you want to get access to. You can access an instance
        /// in any status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceId { get; set; }
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
            
            context.FleetId = this.FleetId;
            context.InstanceId = this.InstanceId;
            
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
            var request = new Amazon.GameLift.Model.GetInstanceAccessRequest();
            
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InstanceAccess;
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
        
        private Amazon.GameLift.Model.GetInstanceAccessResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.GetInstanceAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "GetInstanceAccess");
            try
            {
                #if DESKTOP
                return client.GetInstanceAccess(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetInstanceAccessAsync(request);
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
            public System.String FleetId { get; set; }
            public System.String InstanceId { get; set; }
        }
        
    }
}
