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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Activates a public third-party extension, making it available for use in stack templates.
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/registry-public.html">Using
    /// public extensions</a> in the <i>CloudFormation User Guide</i>.
    /// 
    ///  
    /// <para>
    /// Once you have activated a public third-party extension in your account and region,
    /// use <a href="AWSCloudFormation/latest/APIReference/API_SetTypeConfiguration.html">SetTypeConfiguration</a>
    /// to specify configuration properties for the extension. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/registry-register.html#registry-set-configuration">Configuring
    /// extensions at the account level</a> in the <i>CloudFormation User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "CFNType")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation ActivateType API operation.", Operation = new[] {"ActivateType"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.ActivateTypeResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.ActivateTypeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.ActivateTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableCFNTypeCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter AutoUpdate
        /// <summary>
        /// <para>
        /// <para>Whether to automatically update the extension in this account and region when a new
        /// <i>minor</i> version is published by the extension publisher. Major versions released
        /// by the publisher must be manually updated.</para><para>The default is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoUpdate { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The name of the IAM execution role to use to activate the extension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The Amazon CloudWatch log group to which CloudFormation sends error logging information
        /// when invoking the extension's handlers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfig_LogGroupName { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_LogRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that CloudFormation should assume when sending log entries to
        /// CloudWatch logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfig_LogRoleArn { get; set; }
        #endregion
        
        #region Parameter MajorVersion
        /// <summary>
        /// <para>
        /// <para>The major version of this extension you want to activate, if multiple major versions
        /// are available. The default is the latest major version. CloudFormation uses the latest
        /// available <i>minor</i> version of the major version selected.</para><para>You can specify <code>MajorVersion</code> or <code>VersionBump</code>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? MajorVersion { get; set; }
        #endregion
        
        #region Parameter PublicTypeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the public extension.</para><para>Conditional: You must specify <code>PublicTypeArn</code>, or <code>TypeName</code>,
        /// <code>Type</code>, and <code>PublisherId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PublicTypeArn { get; set; }
        #endregion
        
        #region Parameter PublisherId
        /// <summary>
        /// <para>
        /// <para>The ID of the extension publisher.</para><para>Conditional: You must specify <code>PublicTypeArn</code>, or <code>TypeName</code>,
        /// <code>Type</code>, and <code>PublisherId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PublisherId { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The extension type.</para><para>Conditional: You must specify <code>PublicTypeArn</code>, or <code>TypeName</code>,
        /// <code>Type</code>, and <code>PublisherId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.ThirdPartyType")]
        public Amazon.CloudFormation.ThirdPartyType Type { get; set; }
        #endregion
        
        #region Parameter TypeName
        /// <summary>
        /// <para>
        /// <para>The name of the extension.</para><para>Conditional: You must specify <code>PublicTypeArn</code>, or <code>TypeName</code>,
        /// <code>Type</code>, and <code>PublisherId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeName { get; set; }
        #endregion
        
        #region Parameter TypeNameAlias
        /// <summary>
        /// <para>
        /// <para>An alias to assign to the public extension, in this account and region. If you specify
        /// an alias for the extension, CloudFormation treats the alias as the extension type
        /// name within this account and region. You must use the alias to refer to the extension
        /// in your templates, API calls, and CloudFormation console.</para><para>An extension alias must be unique within a given account and region. You can activate
        /// the same public resource multiple times in the same account and region, using different
        /// type name aliases.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeNameAlias { get; set; }
        #endregion
        
        #region Parameter VersionBump
        /// <summary>
        /// <para>
        /// <para>Manually updates a previously-activated type to a new major or minor version, if available.
        /// You can also use this parameter to update the value of <code>AutoUpdate</code>.</para><ul><li><para><code>MAJOR</code>: CloudFormation updates the extension to the newest major version,
        /// if one is available.</para></li><li><para><code>MINOR</code>: CloudFormation updates the extension to the newest minor version,
        /// if one is available.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.VersionBump")]
        public Amazon.CloudFormation.VersionBump VersionBump { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.ActivateTypeResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.ActivateTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.ActivateTypeResponse, EnableCFNTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoUpdate = this.AutoUpdate;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.LoggingConfig_LogGroupName = this.LoggingConfig_LogGroupName;
            context.LoggingConfig_LogRoleArn = this.LoggingConfig_LogRoleArn;
            context.MajorVersion = this.MajorVersion;
            context.PublicTypeArn = this.PublicTypeArn;
            context.PublisherId = this.PublisherId;
            context.Type = this.Type;
            context.TypeName = this.TypeName;
            context.TypeNameAlias = this.TypeNameAlias;
            context.VersionBump = this.VersionBump;
            
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
            var request = new Amazon.CloudFormation.Model.ActivateTypeRequest();
            
            if (cmdletContext.AutoUpdate != null)
            {
                request.AutoUpdate = cmdletContext.AutoUpdate.Value;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate LoggingConfig
            var requestLoggingConfigIsNull = true;
            request.LoggingConfig = new Amazon.CloudFormation.Model.LoggingConfig();
            System.String requestLoggingConfig_loggingConfig_LogGroupName = null;
            if (cmdletContext.LoggingConfig_LogGroupName != null)
            {
                requestLoggingConfig_loggingConfig_LogGroupName = cmdletContext.LoggingConfig_LogGroupName;
            }
            if (requestLoggingConfig_loggingConfig_LogGroupName != null)
            {
                request.LoggingConfig.LogGroupName = requestLoggingConfig_loggingConfig_LogGroupName;
                requestLoggingConfigIsNull = false;
            }
            System.String requestLoggingConfig_loggingConfig_LogRoleArn = null;
            if (cmdletContext.LoggingConfig_LogRoleArn != null)
            {
                requestLoggingConfig_loggingConfig_LogRoleArn = cmdletContext.LoggingConfig_LogRoleArn;
            }
            if (requestLoggingConfig_loggingConfig_LogRoleArn != null)
            {
                request.LoggingConfig.LogRoleArn = requestLoggingConfig_loggingConfig_LogRoleArn;
                requestLoggingConfigIsNull = false;
            }
             // determine if request.LoggingConfig should be set to null
            if (requestLoggingConfigIsNull)
            {
                request.LoggingConfig = null;
            }
            if (cmdletContext.MajorVersion != null)
            {
                request.MajorVersion = cmdletContext.MajorVersion.Value;
            }
            if (cmdletContext.PublicTypeArn != null)
            {
                request.PublicTypeArn = cmdletContext.PublicTypeArn;
            }
            if (cmdletContext.PublisherId != null)
            {
                request.PublisherId = cmdletContext.PublisherId;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.TypeName != null)
            {
                request.TypeName = cmdletContext.TypeName;
            }
            if (cmdletContext.TypeNameAlias != null)
            {
                request.TypeNameAlias = cmdletContext.TypeNameAlias;
            }
            if (cmdletContext.VersionBump != null)
            {
                request.VersionBump = cmdletContext.VersionBump;
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
        
        private Amazon.CloudFormation.Model.ActivateTypeResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.ActivateTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "ActivateType");
            try
            {
                #if DESKTOP
                return client.ActivateType(request);
                #elif CORECLR
                return client.ActivateTypeAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AutoUpdate { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String LoggingConfig_LogGroupName { get; set; }
            public System.String LoggingConfig_LogRoleArn { get; set; }
            public System.Int64? MajorVersion { get; set; }
            public System.String PublicTypeArn { get; set; }
            public System.String PublisherId { get; set; }
            public Amazon.CloudFormation.ThirdPartyType Type { get; set; }
            public System.String TypeName { get; set; }
            public System.String TypeNameAlias { get; set; }
            public Amazon.CloudFormation.VersionBump VersionBump { get; set; }
            public System.Func<Amazon.CloudFormation.Model.ActivateTypeResponse, EnableCFNTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
