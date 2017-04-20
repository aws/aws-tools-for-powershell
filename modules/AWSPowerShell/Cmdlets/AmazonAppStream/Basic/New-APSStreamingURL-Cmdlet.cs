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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Gives a URL to start a AppStream stream for a user. The URL is valid only for 1 minute
    /// from the time that it is generated.
    /// </summary>
    [Cmdlet("New", "APSStreamingURL", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.CreateStreamingURLResponse")]
    [AWSCmdlet("Invokes the CreateStreamingURL operation against AWS AppStream.", Operation = new[] {"CreateStreamingURL"})]
    [AWSCmdletOutput("Amazon.AppStream.Model.CreateStreamingURLResponse",
        "This cmdlet returns a Amazon.AppStream.Model.CreateStreamingURLResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAPSStreamingURLCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>ID of the application that must be launched after the session starts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter FleetName
        /// <summary>
        /// <para>
        /// <para>The fleet for which the URL is generated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FleetName { get; set; }
        #endregion
        
        #region Parameter SessionContext
        /// <summary>
        /// <para>
        /// <para>The sessionContext of the AppStream stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SessionContext { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The stack for which the URL is generated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>A unique user ID for which the URL is generated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Validity
        /// <summary>
        /// <para>
        /// <para>The validity duration of the URL in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 Validity { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSStreamingURL (CreateStreamingURL)"))
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
            
            context.ApplicationId = this.ApplicationId;
            context.FleetName = this.FleetName;
            context.SessionContext = this.SessionContext;
            context.StackName = this.StackName;
            context.UserId = this.UserId;
            if (ParameterWasBound("Validity"))
                context.Validity = this.Validity;
            
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
            var request = new Amazon.AppStream.Model.CreateStreamingURLRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.FleetName != null)
            {
                request.FleetName = cmdletContext.FleetName;
            }
            if (cmdletContext.SessionContext != null)
            {
                request.SessionContext = cmdletContext.SessionContext;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            if (cmdletContext.Validity != null)
            {
                request.Validity = cmdletContext.Validity.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.AppStream.Model.CreateStreamingURLResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateStreamingURLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppStream", "CreateStreamingURL");
            #if DESKTOP
            return client.CreateStreamingURL(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateStreamingURLAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ApplicationId { get; set; }
            public System.String FleetName { get; set; }
            public System.String SessionContext { get; set; }
            public System.String StackName { get; set; }
            public System.String UserId { get; set; }
            public System.Int64? Validity { get; set; }
        }
        
    }
}
