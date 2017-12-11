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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Creates a <code>GraphqlApi</code> object.
    /// </summary>
    [Cmdlet("New", "ASYNGraphqlApi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.GraphqlApi")]
    [AWSCmdlet("Calls the AWS AppSync CreateGraphqlApi API operation.", Operation = new[] {"CreateGraphqlApi"})]
    [AWSCmdletOutput("Amazon.AppSync.Model.GraphqlApi",
        "This cmdlet returns a GraphqlApi object.",
        "The service call response (type Amazon.AppSync.Model.CreateGraphqlApiResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewASYNGraphqlApiCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        #region Parameter AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The authentication type: API key, IAM, or Amazon Cognito User Pools.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AppSync.AuthenticationType")]
        public Amazon.AppSync.AuthenticationType AuthenticationType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A user-supplied name for the <code>GraphqlApi</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter UserPoolConfig
        /// <summary>
        /// <para>
        /// <para>The Amazon Cognito User Pool configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AppSync.Model.UserPoolConfig UserPoolConfig { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASYNGraphqlApi (CreateGraphqlApi)"))
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
            
            context.AuthenticationType = this.AuthenticationType;
            context.Name = this.Name;
            context.UserPoolConfig = this.UserPoolConfig;
            
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
            var request = new Amazon.AppSync.Model.CreateGraphqlApiRequest();
            
            if (cmdletContext.AuthenticationType != null)
            {
                request.AuthenticationType = cmdletContext.AuthenticationType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.UserPoolConfig != null)
            {
                request.UserPoolConfig = cmdletContext.UserPoolConfig;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GraphqlApi;
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
        
        private Amazon.AppSync.Model.CreateGraphqlApiResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.CreateGraphqlApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "CreateGraphqlApi");
            try
            {
                #if DESKTOP
                return client.CreateGraphqlApi(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateGraphqlApiAsync(request);
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
            public Amazon.AppSync.AuthenticationType AuthenticationType { get; set; }
            public System.String Name { get; set; }
            public Amazon.AppSync.Model.UserPoolConfig UserPoolConfig { get; set; }
        }
        
    }
}
