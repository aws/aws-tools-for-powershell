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
using Amazon.CodeStar;
using Amazon.CodeStar.Model;

namespace Amazon.PowerShell.Cmdlets.CST
{
    /// <summary>
    /// Creates a project, including project resources. This action creates a project based
    /// on a submitted project request. A set of source code files and a toolchain template
    /// file can be included with the project request. If these are not provided, an empty
    /// project is created.
    /// </summary>
    [Cmdlet("New", "CSTProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeStar.Model.CreateProjectResponse")]
    [AWSCmdlet("Calls the AWS CodeStar CreateProject API operation.", Operation = new[] {"CreateProject"}, SelectReturnType = typeof(Amazon.CodeStar.Model.CreateProjectResponse))]
    [AWSCmdletOutput("Amazon.CodeStar.Model.CreateProjectResponse",
        "This cmdlet returns an Amazon.CodeStar.Model.CreateProjectResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCSTProjectCmdlet : AmazonCodeStarClientCmdlet, IExecutor
    {
        
        #region Parameter S3_BucketKey
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 object key where the source code files provided with the project request
        /// are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Toolchain_Source_S3_BucketKey")]
        public System.String S3_BucketKey { get; set; }
        #endregion
        
        #region Parameter S3_BucketName
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name where the source code files provided with the project request
        /// are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Toolchain_Source_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A user- or system-generated token that identifies the entity that requested project
        /// creation. This token can be used to repeat the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the project, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the project to be created in AWS CodeStar.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The display name for the project to be created in AWS CodeStar.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Toolchain_RoleArn
        /// <summary>
        /// <para>
        /// <para>The service role ARN for AWS CodeStar to use for the toolchain template during stack
        /// provisioning.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Toolchain_RoleArn { get; set; }
        #endregion
        
        #region Parameter SourceCode
        /// <summary>
        /// <para>
        /// <para>A list of the Code objects submitted with the project request. If this parameter is
        /// specified, the request must also include the toolchain parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CodeStar.Model.Code[] SourceCode { get; set; }
        #endregion
        
        #region Parameter Toolchain_StackParameter
        /// <summary>
        /// <para>
        /// <para>The list of parameter overrides to be passed into the toolchain template during stack
        /// provisioning, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Toolchain_StackParameters")]
        public System.Collections.Hashtable Toolchain_StackParameter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags created for the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeStar.Model.CreateProjectResponse).
        /// Specifying the name of a property of type Amazon.CodeStar.Model.CreateProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CSTProject (CreateProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeStar.Model.CreateProjectResponse, NewCSTProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SourceCode != null)
            {
                context.SourceCode = new List<Amazon.CodeStar.Model.Code>(this.SourceCode);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.Toolchain_RoleArn = this.Toolchain_RoleArn;
            context.S3_BucketKey = this.S3_BucketKey;
            context.S3_BucketName = this.S3_BucketName;
            if (this.Toolchain_StackParameter != null)
            {
                context.Toolchain_StackParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Toolchain_StackParameter.Keys)
                {
                    context.Toolchain_StackParameter.Add((String)hashKey, (String)(this.Toolchain_StackParameter[hashKey]));
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
            var request = new Amazon.CodeStar.Model.CreateProjectRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SourceCode != null)
            {
                request.SourceCode = cmdletContext.SourceCode;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Toolchain
            var requestToolchainIsNull = true;
            request.Toolchain = new Amazon.CodeStar.Model.Toolchain();
            System.String requestToolchain_toolchain_RoleArn = null;
            if (cmdletContext.Toolchain_RoleArn != null)
            {
                requestToolchain_toolchain_RoleArn = cmdletContext.Toolchain_RoleArn;
            }
            if (requestToolchain_toolchain_RoleArn != null)
            {
                request.Toolchain.RoleArn = requestToolchain_toolchain_RoleArn;
                requestToolchainIsNull = false;
            }
            Dictionary<System.String, System.String> requestToolchain_toolchain_StackParameter = null;
            if (cmdletContext.Toolchain_StackParameter != null)
            {
                requestToolchain_toolchain_StackParameter = cmdletContext.Toolchain_StackParameter;
            }
            if (requestToolchain_toolchain_StackParameter != null)
            {
                request.Toolchain.StackParameters = requestToolchain_toolchain_StackParameter;
                requestToolchainIsNull = false;
            }
            Amazon.CodeStar.Model.ToolchainSource requestToolchain_toolchain_Source = null;
            
             // populate Source
            var requestToolchain_toolchain_SourceIsNull = true;
            requestToolchain_toolchain_Source = new Amazon.CodeStar.Model.ToolchainSource();
            Amazon.CodeStar.Model.S3Location requestToolchain_toolchain_Source_toolchain_Source_S3 = null;
            
             // populate S3
            var requestToolchain_toolchain_Source_toolchain_Source_S3IsNull = true;
            requestToolchain_toolchain_Source_toolchain_Source_S3 = new Amazon.CodeStar.Model.S3Location();
            System.String requestToolchain_toolchain_Source_toolchain_Source_S3_s3_BucketKey = null;
            if (cmdletContext.S3_BucketKey != null)
            {
                requestToolchain_toolchain_Source_toolchain_Source_S3_s3_BucketKey = cmdletContext.S3_BucketKey;
            }
            if (requestToolchain_toolchain_Source_toolchain_Source_S3_s3_BucketKey != null)
            {
                requestToolchain_toolchain_Source_toolchain_Source_S3.BucketKey = requestToolchain_toolchain_Source_toolchain_Source_S3_s3_BucketKey;
                requestToolchain_toolchain_Source_toolchain_Source_S3IsNull = false;
            }
            System.String requestToolchain_toolchain_Source_toolchain_Source_S3_s3_BucketName = null;
            if (cmdletContext.S3_BucketName != null)
            {
                requestToolchain_toolchain_Source_toolchain_Source_S3_s3_BucketName = cmdletContext.S3_BucketName;
            }
            if (requestToolchain_toolchain_Source_toolchain_Source_S3_s3_BucketName != null)
            {
                requestToolchain_toolchain_Source_toolchain_Source_S3.BucketName = requestToolchain_toolchain_Source_toolchain_Source_S3_s3_BucketName;
                requestToolchain_toolchain_Source_toolchain_Source_S3IsNull = false;
            }
             // determine if requestToolchain_toolchain_Source_toolchain_Source_S3 should be set to null
            if (requestToolchain_toolchain_Source_toolchain_Source_S3IsNull)
            {
                requestToolchain_toolchain_Source_toolchain_Source_S3 = null;
            }
            if (requestToolchain_toolchain_Source_toolchain_Source_S3 != null)
            {
                requestToolchain_toolchain_Source.S3 = requestToolchain_toolchain_Source_toolchain_Source_S3;
                requestToolchain_toolchain_SourceIsNull = false;
            }
             // determine if requestToolchain_toolchain_Source should be set to null
            if (requestToolchain_toolchain_SourceIsNull)
            {
                requestToolchain_toolchain_Source = null;
            }
            if (requestToolchain_toolchain_Source != null)
            {
                request.Toolchain.Source = requestToolchain_toolchain_Source;
                requestToolchainIsNull = false;
            }
             // determine if request.Toolchain should be set to null
            if (requestToolchainIsNull)
            {
                request.Toolchain = null;
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
        
        private Amazon.CodeStar.Model.CreateProjectResponse CallAWSServiceOperation(IAmazonCodeStar client, Amazon.CodeStar.Model.CreateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeStar", "CreateProject");
            try
            {
                #if DESKTOP
                return client.CreateProject(request);
                #elif CORECLR
                return client.CreateProjectAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.CodeStar.Model.Code> SourceCode { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Toolchain_RoleArn { get; set; }
            public System.String S3_BucketKey { get; set; }
            public System.String S3_BucketName { get; set; }
            public Dictionary<System.String, System.String> Toolchain_StackParameter { get; set; }
            public System.Func<Amazon.CodeStar.Model.CreateProjectResponse, NewCSTProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
