/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Amplify;
using Amazon.Amplify.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMP
{
    /// <summary>
    /// Creates a new branch for an Amplify app.
    /// </summary>
    [Cmdlet("New", "AMPBranch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Amplify.Model.Branch")]
    [AWSCmdlet("Calls the AWS Amplify CreateBranch API operation.", Operation = new[] {"CreateBranch"}, SelectReturnType = typeof(Amazon.Amplify.Model.CreateBranchResponse))]
    [AWSCmdletOutput("Amazon.Amplify.Model.Branch or Amazon.Amplify.Model.CreateBranchResponse",
        "This cmdlet returns an Amazon.Amplify.Model.Branch object.",
        "The service call response (type Amazon.Amplify.Model.CreateBranchResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAMPBranchCmdlet : AmazonAmplifyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para> The unique ID for an Amplify app. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter BackendEnvironmentArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for a backend environment that is part of a Gen 1 Amplify
        /// app. </para><para>This field is available to Amplify Gen 1 apps only where the backend is created using
        /// Amplify Studio or the Amplify command line interface (CLI).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BackendEnvironmentArn { get; set; }
        #endregion
        
        #region Parameter BasicAuthCredential
        /// <summary>
        /// <para>
        /// <para> The basic authorization credentials for the branch. You must base64-encode the authorization
        /// credentials and provide them in the format <c>user:password</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BasicAuthCredentials")]
        public System.String BasicAuthCredential { get; set; }
        #endregion
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para>The name for the branch. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BranchName { get; set; }
        #endregion
        
        #region Parameter BuildSpec
        /// <summary>
        /// <para>
        /// <para> The build specification (build spec) for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuildSpec { get; set; }
        #endregion
        
        #region Parameter ComputeRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to assign to a branch of an SSR app.
        /// The SSR Compute role allows the Amplify Hosting compute service to securely access
        /// specific Amazon Web Services resources based on the role's permissions. For more information
        /// about the SSR Compute role, see <a href="https://docs.aws.amazon.com/amplify/latest/userguide/amplify-SSR-compute-role.html">Adding
        /// an SSR Compute role</a> in the <i>Amplify User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeRoleArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para> The display name for a branch. This is used as the default domain prefix. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EnableAutoBuild
        /// <summary>
        /// <para>
        /// <para> Enables auto building for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableAutoBuild { get; set; }
        #endregion
        
        #region Parameter EnableBasicAuth
        /// <summary>
        /// <para>
        /// <para> Enables basic authorization for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableBasicAuth { get; set; }
        #endregion
        
        #region Parameter EnableNotification
        /// <summary>
        /// <para>
        /// <para> Enables notifications for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableNotification { get; set; }
        #endregion
        
        #region Parameter EnablePerformanceMode
        /// <summary>
        /// <para>
        /// <para>Enables performance mode for the branch.</para><para>Performance mode optimizes for faster hosting performance by keeping content cached
        /// at the edge for a longer interval. When performance mode is enabled, hosting configuration
        /// or code changes can take up to 10 minutes to roll out. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnablePerformanceMode { get; set; }
        #endregion
        
        #region Parameter EnablePullRequestPreview
        /// <summary>
        /// <para>
        /// <para> Enables pull request previews for this branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnablePullRequestPreview { get; set; }
        #endregion
        
        #region Parameter EnableSkewProtection
        /// <summary>
        /// <para>
        /// <para>Specifies whether the skew protection feature is enabled for the branch.</para><para>Deployment skew protection is available to Amplify applications to eliminate version
        /// skew issues between client and servers in web applications. When you apply skew protection
        /// to a branch, you can ensure that your clients always interact with the correct version
        /// of server-side assets, regardless of when a deployment occurs. For more information
        /// about skew protection, see <a href="https://docs.aws.amazon.com/amplify/latest/userguide/skew-protection.html">Skew
        /// protection for Amplify deployments</a> in the <i>Amplify User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableSkewProtection { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para> The environment variables for the branch. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter Framework
        /// <summary>
        /// <para>
        /// <para> The framework for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Framework { get; set; }
        #endregion
        
        #region Parameter PullRequestEnvironmentName
        /// <summary>
        /// <para>
        /// <para> The Amplify environment name for the pull request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PullRequestEnvironmentName { get; set; }
        #endregion
        
        #region Parameter Backend_StackArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the CloudFormation stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Backend_StackArn { get; set; }
        #endregion
        
        #region Parameter Stage
        /// <summary>
        /// <para>
        /// <para>Describes the current stage for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Amplify.Stage")]
        public Amazon.Amplify.Stage Stage { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> The tag for the branch. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Ttl
        /// <summary>
        /// <para>
        /// <para> The content Time To Live (TTL) for the website in seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ttl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Branch'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Amplify.Model.CreateBranchResponse).
        /// Specifying the name of a property of type Amazon.Amplify.Model.CreateBranchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Branch";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BranchName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPBranch (CreateBranch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Amplify.Model.CreateBranchResponse, NewAMPBranchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Backend_StackArn = this.Backend_StackArn;
            context.BackendEnvironmentArn = this.BackendEnvironmentArn;
            context.BasicAuthCredential = this.BasicAuthCredential;
            context.BranchName = this.BranchName;
            #if MODULAR
            if (this.BranchName == null && ParameterWasBound(nameof(this.BranchName)))
            {
                WriteWarning("You are passing $null as a value for parameter BranchName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BuildSpec = this.BuildSpec;
            context.ComputeRoleArn = this.ComputeRoleArn;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.EnableAutoBuild = this.EnableAutoBuild;
            context.EnableBasicAuth = this.EnableBasicAuth;
            context.EnableNotification = this.EnableNotification;
            context.EnablePerformanceMode = this.EnablePerformanceMode;
            context.EnablePullRequestPreview = this.EnablePullRequestPreview;
            context.EnableSkewProtection = this.EnableSkewProtection;
            if (this.EnvironmentVariable != null)
            {
                context.EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentVariable.Keys)
                {
                    context.EnvironmentVariable.Add((String)hashKey, (System.String)(this.EnvironmentVariable[hashKey]));
                }
            }
            context.Framework = this.Framework;
            context.PullRequestEnvironmentName = this.PullRequestEnvironmentName;
            context.Stage = this.Stage;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            
             // populate Backend
            var requestBackendIsNull = true;
            request.Backend = new Amazon.Amplify.Model.Backend();
            System.String requestBackend_backend_StackArn = null;
            if (cmdletContext.Backend_StackArn != null)
            {
                requestBackend_backend_StackArn = cmdletContext.Backend_StackArn;
            }
            if (requestBackend_backend_StackArn != null)
            {
                request.Backend.StackArn = requestBackend_backend_StackArn;
                requestBackendIsNull = false;
            }
             // determine if request.Backend should be set to null
            if (requestBackendIsNull)
            {
                request.Backend = null;
            }
            if (cmdletContext.BackendEnvironmentArn != null)
            {
                request.BackendEnvironmentArn = cmdletContext.BackendEnvironmentArn;
            }
            if (cmdletContext.BasicAuthCredential != null)
            {
                request.BasicAuthCredentials = cmdletContext.BasicAuthCredential;
            }
            if (cmdletContext.BranchName != null)
            {
                request.BranchName = cmdletContext.BranchName;
            }
            if (cmdletContext.BuildSpec != null)
            {
                request.BuildSpec = cmdletContext.BuildSpec;
            }
            if (cmdletContext.ComputeRoleArn != null)
            {
                request.ComputeRoleArn = cmdletContext.ComputeRoleArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
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
            if (cmdletContext.EnablePerformanceMode != null)
            {
                request.EnablePerformanceMode = cmdletContext.EnablePerformanceMode.Value;
            }
            if (cmdletContext.EnablePullRequestPreview != null)
            {
                request.EnablePullRequestPreview = cmdletContext.EnablePullRequestPreview.Value;
            }
            if (cmdletContext.EnableSkewProtection != null)
            {
                request.EnableSkewProtection = cmdletContext.EnableSkewProtection.Value;
            }
            if (cmdletContext.EnvironmentVariable != null)
            {
                request.EnvironmentVariables = cmdletContext.EnvironmentVariable;
            }
            if (cmdletContext.Framework != null)
            {
                request.Framework = cmdletContext.Framework;
            }
            if (cmdletContext.PullRequestEnvironmentName != null)
            {
                request.PullRequestEnvironmentName = cmdletContext.PullRequestEnvironmentName;
            }
            if (cmdletContext.Stage != null)
            {
                request.Stage = cmdletContext.Stage;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Ttl != null)
            {
                request.Ttl = cmdletContext.Ttl;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.CreateBranchAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Backend_StackArn { get; set; }
            public System.String BackendEnvironmentArn { get; set; }
            public System.String BasicAuthCredential { get; set; }
            public System.String BranchName { get; set; }
            public System.String BuildSpec { get; set; }
            public System.String ComputeRoleArn { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.Boolean? EnableAutoBuild { get; set; }
            public System.Boolean? EnableBasicAuth { get; set; }
            public System.Boolean? EnableNotification { get; set; }
            public System.Boolean? EnablePerformanceMode { get; set; }
            public System.Boolean? EnablePullRequestPreview { get; set; }
            public System.Boolean? EnableSkewProtection { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariable { get; set; }
            public System.String Framework { get; set; }
            public System.String PullRequestEnvironmentName { get; set; }
            public Amazon.Amplify.Stage Stage { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Ttl { get; set; }
            public System.Func<Amazon.Amplify.Model.CreateBranchResponse, NewAMPBranchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Branch;
        }
        
    }
}
