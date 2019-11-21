/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates a branch for an Amplify App.
    /// </summary>
    [Cmdlet("Update", "AMPBranch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Amplify.Model.Branch")]
    [AWSCmdlet("Calls the AWS Amplify UpdateBranch API operation.", Operation = new[] {"UpdateBranch"}, SelectReturnType = typeof(Amazon.Amplify.Model.UpdateBranchResponse))]
    [AWSCmdletOutput("Amazon.Amplify.Model.Branch or Amazon.Amplify.Model.UpdateBranchResponse",
        "This cmdlet returns an Amazon.Amplify.Model.Branch object.",
        "The service call response (type Amazon.Amplify.Model.UpdateBranchResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAMPBranchCmdlet : AmazonAmplifyClientCmdlet, IExecutor
    {
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para> Unique Id for an Amplify App. </para>
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
        
        #region Parameter BasicAuthCredential
        /// <summary>
        /// <para>
        /// <para> Basic Authorization credentials for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BasicAuthCredentials")]
        public System.String BasicAuthCredential { get; set; }
        #endregion
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para> Name for the branch. </para>
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
        /// <para> BuildSpec for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuildSpec { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> Description for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para> Display name for a branch, will use as the default domain prefix. </para>
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
        /// <para> Enables Basic Auth for the branch. </para>
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
        
        #region Parameter EnablePullRequestPreview
        /// <summary>
        /// <para>
        /// <para> Enables Pull Request Preview for this branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnablePullRequestPreview { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para> Environment Variables for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter Framework
        /// <summary>
        /// <para>
        /// <para> Framework for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Framework { get; set; }
        #endregion
        
        #region Parameter Stage
        /// <summary>
        /// <para>
        /// <para> Stage for the branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Amplify.Stage")]
        public Amazon.Amplify.Stage Stage { get; set; }
        #endregion
        
        #region Parameter Ttl
        /// <summary>
        /// <para>
        /// <para> The content TTL for the website in seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ttl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Branch'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Amplify.Model.UpdateBranchResponse).
        /// Specifying the name of a property of type Amazon.Amplify.Model.UpdateBranchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Branch";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BranchName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BranchName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BranchName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BranchName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMPBranch (UpdateBranch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Amplify.Model.UpdateBranchResponse, UpdateAMPBranchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BranchName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BasicAuthCredential = this.BasicAuthCredential;
            context.BranchName = this.BranchName;
            #if MODULAR
            if (this.BranchName == null && ParameterWasBound(nameof(this.BranchName)))
            {
                WriteWarning("You are passing $null as a value for parameter BranchName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BuildSpec = this.BuildSpec;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.EnableAutoBuild = this.EnableAutoBuild;
            context.EnableBasicAuth = this.EnableBasicAuth;
            context.EnableNotification = this.EnableNotification;
            context.EnablePullRequestPreview = this.EnablePullRequestPreview;
            if (this.EnvironmentVariable != null)
            {
                context.EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentVariable.Keys)
                {
                    context.EnvironmentVariable.Add((String)hashKey, (String)(this.EnvironmentVariable[hashKey]));
                }
            }
            context.Framework = this.Framework;
            context.Stage = this.Stage;
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
            var request = new Amazon.Amplify.Model.UpdateBranchRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
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
            if (cmdletContext.EnablePullRequestPreview != null)
            {
                request.EnablePullRequestPreview = cmdletContext.EnablePullRequestPreview.Value;
            }
            if (cmdletContext.EnvironmentVariable != null)
            {
                request.EnvironmentVariables = cmdletContext.EnvironmentVariable;
            }
            if (cmdletContext.Framework != null)
            {
                request.Framework = cmdletContext.Framework;
            }
            if (cmdletContext.Stage != null)
            {
                request.Stage = cmdletContext.Stage;
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
        
        private Amazon.Amplify.Model.UpdateBranchResponse CallAWSServiceOperation(IAmazonAmplify client, Amazon.Amplify.Model.UpdateBranchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify", "UpdateBranch");
            try
            {
                #if DESKTOP
                return client.UpdateBranch(request);
                #elif CORECLR
                return client.UpdateBranchAsync(request).GetAwaiter().GetResult();
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
            public System.String BasicAuthCredential { get; set; }
            public System.String BranchName { get; set; }
            public System.String BuildSpec { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.Boolean? EnableAutoBuild { get; set; }
            public System.Boolean? EnableBasicAuth { get; set; }
            public System.Boolean? EnableNotification { get; set; }
            public System.Boolean? EnablePullRequestPreview { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariable { get; set; }
            public System.String Framework { get; set; }
            public Amazon.Amplify.Stage Stage { get; set; }
            public System.String Ttl { get; set; }
            public System.Func<Amazon.Amplify.Model.UpdateBranchResponse, UpdateAMPBranchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Branch;
        }
        
    }
}
