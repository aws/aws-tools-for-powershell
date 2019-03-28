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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// Imports the source repository credentials for an AWS CodeBuild project that has its
    /// source code stored in a GitHub, GitHub Enterprise, or Bitbucket repository.
    /// </summary>
    [Cmdlet("Import", "CBSourceCredential", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeBuild ImportSourceCredentials API operation.", Operation = new[] {"ImportSourceCredentials"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CodeBuild.Model.ImportSourceCredentialsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportCBSourceCredentialCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para> The type of authentication used to connect to a GitHub, GitHub Enterprise, or Bitbucket
        /// repository. An OAUTH connection is not supported by the API and must be created using
        /// the AWS CodeBuild console. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.AuthType")]
        public Amazon.CodeBuild.AuthType AuthType { get; set; }
        #endregion
        
        #region Parameter ServerType
        /// <summary>
        /// <para>
        /// <para> The source provider used for this project. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ServerType")]
        public Amazon.CodeBuild.ServerType ServerType { get; set; }
        #endregion
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para> For GitHub or GitHub Enterprise, this is the personal access token. For Bitbucket,
        /// this is the app password. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Token { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para> The Bitbucket username when the <code>authType</code> is BASIC_AUTH. This parameter
        /// is not valid for other types of source providers or connections. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Username { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-CBSourceCredential (ImportSourceCredentials)"))
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
            
            context.AuthType = this.AuthType;
            context.ServerType = this.ServerType;
            context.Token = this.Token;
            context.Username = this.Username;
            
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
            var request = new Amazon.CodeBuild.Model.ImportSourceCredentialsRequest();
            
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            if (cmdletContext.ServerType != null)
            {
                request.ServerType = cmdletContext.ServerType;
            }
            if (cmdletContext.Token != null)
            {
                request.Token = cmdletContext.Token;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Arn;
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
        
        private Amazon.CodeBuild.Model.ImportSourceCredentialsResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.ImportSourceCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "ImportSourceCredentials");
            try
            {
                #if DESKTOP
                return client.ImportSourceCredentials(request);
                #elif CORECLR
                return client.ImportSourceCredentialsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CodeBuild.AuthType AuthType { get; set; }
            public Amazon.CodeBuild.ServerType ServerType { get; set; }
            public System.String Token { get; set; }
            public System.String Username { get; set; }
        }
        
    }
}
