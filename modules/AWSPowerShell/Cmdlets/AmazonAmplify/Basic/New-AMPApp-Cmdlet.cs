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
    /// Creates a new Amplify App.
    /// </summary>
    [Cmdlet("New", "AMPApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Amplify.Model.App")]
    [AWSCmdlet("Calls the AWS Amplify CreateApp API operation.", Operation = new[] {"CreateApp"})]
    [AWSCmdletOutput("Amazon.Amplify.Model.App",
        "This cmdlet returns a App object.",
        "The service call response (type Amazon.Amplify.Model.CreateAppResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMPAppCmdlet : AmazonAmplifyClientCmdlet, IExecutor
    {
        
        #region Parameter BasicAuthCredential
        /// <summary>
        /// <para>
        /// <para> Credentials for Basic Authorization for an Amplify App. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BasicAuthCredentials")]
        public System.String BasicAuthCredential { get; set; }
        #endregion
        
        #region Parameter BuildSpec
        /// <summary>
        /// <para>
        /// <para> BuildSpec for an Amplify App </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BuildSpec { get; set; }
        #endregion
        
        #region Parameter CustomRule
        /// <summary>
        /// <para>
        /// <para> Custom rewrite / redirect rules for an Amplify App. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CustomRules")]
        public Amazon.Amplify.Model.CustomRule[] CustomRule { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> Description for an Amplify App </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnableBasicAuth
        /// <summary>
        /// <para>
        /// <para> Enable Basic Authorization for an Amplify App, this will apply to all branches part
        /// of this App. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableBasicAuth { get; set; }
        #endregion
        
        #region Parameter EnableBranchAutoBuild
        /// <summary>
        /// <para>
        /// <para> Enable the auto building of branches for an Amplify App. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableBranchAutoBuild { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para> Environment variables map for an Amplify App. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter IamServiceRoleArn
        /// <summary>
        /// <para>
        /// <para> AWS IAM service role for an Amplify App </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IamServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> Name for the Amplify App </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OauthToken
        /// <summary>
        /// <para>
        /// <para> OAuth token for 3rd party source control system for an Amplify App, used to create
        /// webhook and read-only deploy key. OAuth token is not stored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OauthToken { get; set; }
        #endregion
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para> Platform / framework for an Amplify App </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Amplify.Platform")]
        public Amazon.Amplify.Platform Platform { get; set; }
        #endregion
        
        #region Parameter Repository
        /// <summary>
        /// <para>
        /// <para> Repository for an Amplify App </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Repository { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> Tag for an Amplify App </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPApp (CreateApp)"))
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
            
            context.BasicAuthCredentials = this.BasicAuthCredential;
            context.BuildSpec = this.BuildSpec;
            if (this.CustomRule != null)
            {
                context.CustomRules = new List<Amazon.Amplify.Model.CustomRule>(this.CustomRule);
            }
            context.Description = this.Description;
            if (ParameterWasBound("EnableBasicAuth"))
                context.EnableBasicAuth = this.EnableBasicAuth;
            if (ParameterWasBound("EnableBranchAutoBuild"))
                context.EnableBranchAutoBuild = this.EnableBranchAutoBuild;
            if (this.EnvironmentVariable != null)
            {
                context.EnvironmentVariables = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentVariable.Keys)
                {
                    context.EnvironmentVariables.Add((String)hashKey, (String)(this.EnvironmentVariable[hashKey]));
                }
            }
            context.IamServiceRoleArn = this.IamServiceRoleArn;
            context.Name = this.Name;
            context.OauthToken = this.OauthToken;
            context.Platform = this.Platform;
            context.Repository = this.Repository;
            if (this.Tag != null)
            {
                context.Tags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tags.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Amplify.Model.CreateAppRequest();
            
            if (cmdletContext.BasicAuthCredentials != null)
            {
                request.BasicAuthCredentials = cmdletContext.BasicAuthCredentials;
            }
            if (cmdletContext.BuildSpec != null)
            {
                request.BuildSpec = cmdletContext.BuildSpec;
            }
            if (cmdletContext.CustomRules != null)
            {
                request.CustomRules = cmdletContext.CustomRules;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnableBasicAuth != null)
            {
                request.EnableBasicAuth = cmdletContext.EnableBasicAuth.Value;
            }
            if (cmdletContext.EnableBranchAutoBuild != null)
            {
                request.EnableBranchAutoBuild = cmdletContext.EnableBranchAutoBuild.Value;
            }
            if (cmdletContext.EnvironmentVariables != null)
            {
                request.EnvironmentVariables = cmdletContext.EnvironmentVariables;
            }
            if (cmdletContext.IamServiceRoleArn != null)
            {
                request.IamServiceRoleArn = cmdletContext.IamServiceRoleArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OauthToken != null)
            {
                request.OauthToken = cmdletContext.OauthToken;
            }
            if (cmdletContext.Platform != null)
            {
                request.Platform = cmdletContext.Platform;
            }
            if (cmdletContext.Repository != null)
            {
                request.Repository = cmdletContext.Repository;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.App;
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
        
        private Amazon.Amplify.Model.CreateAppResponse CallAWSServiceOperation(IAmazonAmplify client, Amazon.Amplify.Model.CreateAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify", "CreateApp");
            try
            {
                #if DESKTOP
                return client.CreateApp(request);
                #elif CORECLR
                return client.CreateAppAsync(request).GetAwaiter().GetResult();
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
            public System.String BasicAuthCredentials { get; set; }
            public System.String BuildSpec { get; set; }
            public List<Amazon.Amplify.Model.CustomRule> CustomRules { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? EnableBasicAuth { get; set; }
            public System.Boolean? EnableBranchAutoBuild { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariables { get; set; }
            public System.String IamServiceRoleArn { get; set; }
            public System.String Name { get; set; }
            public System.String OauthToken { get; set; }
            public Amazon.Amplify.Platform Platform { get; set; }
            public System.String Repository { get; set; }
            public Dictionary<System.String, System.String> Tags { get; set; }
        }
        
    }
}
