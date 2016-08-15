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
    /// Retrieves a fresh set of upload credentials and the assigned Amazon S3 storage location
    /// for a specific build. Valid credentials are required to upload your game build files
    /// to Amazon S3.
    /// 
    ///  <important><para>
    /// Call this action only if you need credentials for a build created with <code><a>CreateBuild</a></code>.
    /// This is a rare situation; in most cases, builds are created using the CLI command
    /// <code>upload-build</code>, which creates a build record and also uploads build files.
    /// 
    /// </para></important><para>
    /// Upload credentials are returned when you create the build, but they have a limited
    /// lifespan. You can get fresh credentials and use them to re-upload game files until
    /// the status of that build changes to <code>READY</code>. Once this happens, you must
    /// create a brand new build.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "GMLUploadCredential", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.RequestUploadCredentialsResponse")]
    [AWSCmdlet("Invokes the RequestUploadCredentials operation against Amazon GameLift Service.", Operation = new[] {"RequestUploadCredentials"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.RequestUploadCredentialsResponse",
        "This cmdlet returns a Amazon.GameLift.Model.RequestUploadCredentialsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RequestGMLUploadCredentialCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter BuildId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the build you want to get credentials for. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BuildId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BuildId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-GMLUploadCredential (RequestUploadCredentials)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.BuildId = this.BuildId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.GameLift.Model.RequestUploadCredentialsRequest();
            
            if (cmdletContext.BuildId != null)
            {
                request.BuildId = cmdletContext.BuildId;
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
        
        private static Amazon.GameLift.Model.RequestUploadCredentialsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.RequestUploadCredentialsRequest request)
        {
            return client.RequestUploadCredentials(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String BuildId { get; set; }
        }
        
    }
}
