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
using Amazon.Amplify;
using Amazon.Amplify.Model;

namespace Amazon.PowerShell.Cmdlets.AMP
{
    /// <summary>
    /// Creates a new Branch for an Amplify App.
    /// </summary>
    [Cmdlet("New", "AMPBranch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Amplify.Model.Branch")]
    [AWSCmdlet("Calls the AWS Amplify CreateBranch API operation.", Operation = new[] {"CreateBranch"})]
    [AWSCmdletOutput("Amazon.Amplify.Model.Branch",
        "This cmdlet returns a Branch object.",
        "The service call response (type Amazon.Amplify.Model.CreateBranchResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMPBranchCmdlet : AmazonAmplifyClientCmdlet, IExecutor
    {
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para> Unique Id for an Amplify App. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter BasicAuthCredential
        /// <summary>
        /// <para>
        /// <para> Basic Authorization credentials for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BasicAuthCredentials")]
        public System.String BasicAuthCredential { get; set; }
        #endregion
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para> Name for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String BranchName { get; set; }
        #endregion
        
        #region Parameter BuildSpec
        /// <summary>
        /// <para>
        /// <para> BuildSpec for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BuildSpec { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> Description for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnableAutoBuild
        /// <summary>
        /// <para>
        /// <para> Enables auto building for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableAutoBuild { get; set; }
        #endregion
        
        #region Parameter EnableBasicAuth
        /// <summary>
        /// <para>
        /// <para> Enables Basic Auth for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableBasicAuth { get; set; }
        #endregion
        
        #region Parameter EnableNotification
        /// <summary>
        /// <para>
        /// <para> Enables notifications for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableNotification { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para> Environment Variables for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter Framework
        /// <summary>
        /// <para>
        /// <para> Framework for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Framework { get; set; }
        #endregion
        
        #region Parameter Stage
        /// <summary>
        /// <para>
        /// <para> Stage for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Amplify.Stage")]
        public Amazon.Amplify.Stage Stage { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> Tag for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Ttl
        /// <summary>
        /// <para>
        /// <para> The content TTL for the website in seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Ttl { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BranchName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPBranch (CreateBranch)"))
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
            
            context.AppId = this.AppId;
            context.BasicAuthCredentials = this.BasicAuthCredential;
            context.BranchName = this.BranchName;
            context.BuildSpec = this.BuildSpec;
            context.Description = this.Description;
            if (ParameterWasBound("EnableAutoBuild"))
                context.EnableAutoBuild = this.EnableAutoBuild;
            if (ParameterWasBound("EnableBasicAuth"))
                context.EnableBasicAuth = this.EnableBasicAuth;
            if (ParameterWasBound("EnableNotification"))
                context.EnableNotification = this.EnableNotification;
            if (this.EnvironmentVariable != null)
            {
                context.EnvironmentVariables = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentVariable.Keys)
                {
                    context.EnvironmentVariables.Add((String)hashKey, (String)(this.EnvironmentVariable[hashKey]));
                }
            }
            context.Framework = this.Framework;
            context.Stage = this.Stage;
            if (this.Tag != null)
            {
                context.Tags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tags.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.Ttl = this.Ttl;
            
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
            var request = new Amazon.Amplify.Model.CreateBranchRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.BasicAuthCredentials != null)
            {
                request.BasicAuthCredentials = cmdletContext.BasicAuthCredentials;
            }
            if (cmdletContext.BranchName != null)
            {
                request.BranchName = cmdletContext.BranchName;
            }
            if (cmdletContext.BuildSpec != null)
            {
                request.BuildSpec = cmdletContext.BuildSpec;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnableAutoBuild != null)
            {
                request.EnableAutoBuild = cmdletContext.EnableAutoBuild.Value;
            }
            if (cmdletContext.EnableBasicAuth != null)
            {
                request.EnableBasicAuth = cmdletContext.EnableBasicAuth.Value;
            }
            if (cmdletContext.EnableNotification != null)
            {
                request.EnableNotification = cmdletContext.EnableNotification.Value;
            }
            if (cmdletContext.EnvironmentVariables != null)
            {
                request.EnvironmentVariables = cmdletContext.EnvironmentVariables;
            }
            if (cmdletContext.Framework != null)
            {
                request.Framework = cmdletContext.Framework;
            }
            if (cmdletContext.Stage != null)
            {
                request.Stage = cmdletContext.Stage;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.Ttl != null)
            {
                request.Ttl = cmdletContext.Ttl;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Branch;
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
        
        private Amazon.Amplify.Model.CreateBranchResponse CallAWSServiceOperation(IAmazonAmplify client, Amazon.Amplify.Model.CreateBranchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify", "CreateBranch");
            try
            {
                #if DESKTOP
                return client.CreateBranch(request);
                #elif CORECLR
                return client.CreateBranchAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String BasicAuthCredentials { get; set; }
            public System.String BranchName { get; set; }
            public System.String BuildSpec { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? EnableAutoBuild { get; set; }
            public System.Boolean? EnableBasicAuth { get; set; }
            public System.Boolean? EnableNotification { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariables { get; set; }
            public System.String Framework { get; set; }
            public Amazon.Amplify.Stage Stage { get; set; }
            public Dictionary<System.String, System.String> Tags { get; set; }
            public System.String Ttl { get; set; }
        }
        
    }
}
