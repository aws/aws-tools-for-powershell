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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Updates a specified app.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Deploy or
    /// Manage permissions level for the stack, or an attached policy that explicitly grants
    /// permissions. For more information on user permissions, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OPSApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS OpsWorks UpdateApp API operation.", Operation = new[] {"UpdateApp"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.UpdateAppResponse))]
    [AWSCmdletOutput("None or Amazon.OpsWorks.Model.UpdateAppResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.OpsWorks.Model.UpdateAppResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateOPSAppCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The app ID.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>One or more user-defined key/value pairs to be added to the stack attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter SslConfiguration_Certificate
        /// <summary>
        /// <para>
        /// <para>The contents of the certificate's domain.crt file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SslConfiguration_Certificate { get; set; }
        #endregion
        
        #region Parameter SslConfiguration_Chain
        /// <summary>
        /// <para>
        /// <para>Optional. Can be used to specify an intermediate certificate authority key or client
        /// authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SslConfiguration_Chain { get; set; }
        #endregion
        
        #region Parameter DataSource
        /// <summary>
        /// <para>
        /// <para>The app's data sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources")]
        public Amazon.OpsWorks.Model.DataSource[] DataSource { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The app's virtual host settings, with multiple domains separated by commas. For example:
        /// <c>'www.example.com, example.com'</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Domains")]
        public System.String[] Domain { get; set; }
        #endregion
        
        #region Parameter EnableSsl
        /// <summary>
        /// <para>
        /// <para>Whether SSL is enabled for the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableSsl { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>An array of <c>EnvironmentVariable</c> objects that specify environment variables
        /// to be associated with the app. After you deploy the app, these variables are defined
        /// on the associated app server instances.For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingapps-creating.html#workingapps-creating-environment">
        /// Environment Variables</a>.</para><para>There is no specific limit on the number of environment variables. However, the size
        /// of the associated data structure - which includes the variables' names, values, and
        /// protected flag values - cannot exceed 20 KB. This limit should accommodate most if
        /// not all use cases. Exceeding it will cause an exception with the message, "Environment:
        /// is too large (maximum is 20 KB)."</para><note><para>If you have specified one or more environment variables, you cannot modify the stack's
        /// Chef version.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.OpsWorks.Model.EnvironmentVariable[] Environment { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The app name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter AppSource_Password
        /// <summary>
        /// <para>
        /// <para>When included in a request, the parameter depends on the repository type.</para><ul><li><para>For Amazon S3 bundles, set <c>Password</c> to the appropriate IAM secret access key.</para></li><li><para>For HTTP bundles and Subversion repositories, set <c>Password</c> to the password.</para></li></ul><para>For more information on how to safely handle IAM credentials, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html">https://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html</a>.</para><para>In responses, OpsWorks Stacks returns <c>*****FILTERED*****</c> instead of the actual
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppSource_Password { get; set; }
        #endregion
        
        #region Parameter SslConfiguration_PrivateKey
        /// <summary>
        /// <para>
        /// <para>The private key; the contents of the certificate's domain.kex file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SslConfiguration_PrivateKey { get; set; }
        #endregion
        
        #region Parameter AppSource_Revision
        /// <summary>
        /// <para>
        /// <para>The application's version. OpsWorks Stacks enables you to easily deploy new versions
        /// of an application. One of the simplest approaches is to have branches or revisions
        /// in your repository that represent different versions that can potentially be deployed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppSource_Revision { get; set; }
        #endregion
        
        #region Parameter AppSource_SshKey
        /// <summary>
        /// <para>
        /// <para>In requests, the repository's SSH key.</para><para>In responses, OpsWorks Stacks returns <c>*****FILTERED*****</c> instead of the actual
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppSource_SshKey { get; set; }
        #endregion
        
        #region Parameter AppSource_Type
        /// <summary>
        /// <para>
        /// <para>The repository type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpsWorks.SourceType")]
        public Amazon.OpsWorks.SourceType AppSource_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The app type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpsWorks.AppType")]
        public Amazon.OpsWorks.AppType Type { get; set; }
        #endregion
        
        #region Parameter AppSource_Url
        /// <summary>
        /// <para>
        /// <para>The source URL. The following is an example of an Amazon S3 source URL: <c>https://s3.amazonaws.com/opsworks-demo-bucket/opsworks_cookbook_demo.tar.gz</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppSource_Url { get; set; }
        #endregion
        
        #region Parameter AppSource_Username
        /// <summary>
        /// <para>
        /// <para>This parameter depends on the repository type.</para><ul><li><para>For Amazon S3 bundles, set <c>Username</c> to the appropriate IAM access key ID.</para></li><li><para>For HTTP bundles, Git repositories, and Subversion repositories, set <c>Username</c>
        /// to the user name.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppSource_Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.UpdateAppResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OPSApp (UpdateApp)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.UpdateAppResponse, UpdateOPSAppCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppSource_Password = this.AppSource_Password;
            context.AppSource_Revision = this.AppSource_Revision;
            context.AppSource_SshKey = this.AppSource_SshKey;
            context.AppSource_Type = this.AppSource_Type;
            context.AppSource_Url = this.AppSource_Url;
            context.AppSource_Username = this.AppSource_Username;
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            if (this.DataSource != null)
            {
                context.DataSource = new List<Amazon.OpsWorks.Model.DataSource>(this.DataSource);
            }
            context.Description = this.Description;
            if (this.Domain != null)
            {
                context.Domain = new List<System.String>(this.Domain);
            }
            context.EnableSsl = this.EnableSsl;
            if (this.Environment != null)
            {
                context.Environment = new List<Amazon.OpsWorks.Model.EnvironmentVariable>(this.Environment);
            }
            context.Name = this.Name;
            context.SslConfiguration_Certificate = this.SslConfiguration_Certificate;
            context.SslConfiguration_Chain = this.SslConfiguration_Chain;
            context.SslConfiguration_PrivateKey = this.SslConfiguration_PrivateKey;
            context.Type = this.Type;
            
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
            var request = new Amazon.OpsWorks.Model.UpdateAppRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            
             // populate AppSource
            var requestAppSourceIsNull = true;
            request.AppSource = new Amazon.OpsWorks.Model.Source();
            System.String requestAppSource_appSource_Password = null;
            if (cmdletContext.AppSource_Password != null)
            {
                requestAppSource_appSource_Password = cmdletContext.AppSource_Password;
            }
            if (requestAppSource_appSource_Password != null)
            {
                request.AppSource.Password = requestAppSource_appSource_Password;
                requestAppSourceIsNull = false;
            }
            System.String requestAppSource_appSource_Revision = null;
            if (cmdletContext.AppSource_Revision != null)
            {
                requestAppSource_appSource_Revision = cmdletContext.AppSource_Revision;
            }
            if (requestAppSource_appSource_Revision != null)
            {
                request.AppSource.Revision = requestAppSource_appSource_Revision;
                requestAppSourceIsNull = false;
            }
            System.String requestAppSource_appSource_SshKey = null;
            if (cmdletContext.AppSource_SshKey != null)
            {
                requestAppSource_appSource_SshKey = cmdletContext.AppSource_SshKey;
            }
            if (requestAppSource_appSource_SshKey != null)
            {
                request.AppSource.SshKey = requestAppSource_appSource_SshKey;
                requestAppSourceIsNull = false;
            }
            Amazon.OpsWorks.SourceType requestAppSource_appSource_Type = null;
            if (cmdletContext.AppSource_Type != null)
            {
                requestAppSource_appSource_Type = cmdletContext.AppSource_Type;
            }
            if (requestAppSource_appSource_Type != null)
            {
                request.AppSource.Type = requestAppSource_appSource_Type;
                requestAppSourceIsNull = false;
            }
            System.String requestAppSource_appSource_Url = null;
            if (cmdletContext.AppSource_Url != null)
            {
                requestAppSource_appSource_Url = cmdletContext.AppSource_Url;
            }
            if (requestAppSource_appSource_Url != null)
            {
                request.AppSource.Url = requestAppSource_appSource_Url;
                requestAppSourceIsNull = false;
            }
            System.String requestAppSource_appSource_Username = null;
            if (cmdletContext.AppSource_Username != null)
            {
                requestAppSource_appSource_Username = cmdletContext.AppSource_Username;
            }
            if (requestAppSource_appSource_Username != null)
            {
                request.AppSource.Username = requestAppSource_appSource_Username;
                requestAppSourceIsNull = false;
            }
             // determine if request.AppSource should be set to null
            if (requestAppSourceIsNull)
            {
                request.AppSource = null;
            }
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.DataSource != null)
            {
                request.DataSources = cmdletContext.DataSource;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domains = cmdletContext.Domain;
            }
            if (cmdletContext.EnableSsl != null)
            {
                request.EnableSsl = cmdletContext.EnableSsl.Value;
            }
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate SslConfiguration
            var requestSslConfigurationIsNull = true;
            request.SslConfiguration = new Amazon.OpsWorks.Model.SslConfiguration();
            System.String requestSslConfiguration_sslConfiguration_Certificate = null;
            if (cmdletContext.SslConfiguration_Certificate != null)
            {
                requestSslConfiguration_sslConfiguration_Certificate = cmdletContext.SslConfiguration_Certificate;
            }
            if (requestSslConfiguration_sslConfiguration_Certificate != null)
            {
                request.SslConfiguration.Certificate = requestSslConfiguration_sslConfiguration_Certificate;
                requestSslConfigurationIsNull = false;
            }
            System.String requestSslConfiguration_sslConfiguration_Chain = null;
            if (cmdletContext.SslConfiguration_Chain != null)
            {
                requestSslConfiguration_sslConfiguration_Chain = cmdletContext.SslConfiguration_Chain;
            }
            if (requestSslConfiguration_sslConfiguration_Chain != null)
            {
                request.SslConfiguration.Chain = requestSslConfiguration_sslConfiguration_Chain;
                requestSslConfigurationIsNull = false;
            }
            System.String requestSslConfiguration_sslConfiguration_PrivateKey = null;
            if (cmdletContext.SslConfiguration_PrivateKey != null)
            {
                requestSslConfiguration_sslConfiguration_PrivateKey = cmdletContext.SslConfiguration_PrivateKey;
            }
            if (requestSslConfiguration_sslConfiguration_PrivateKey != null)
            {
                request.SslConfiguration.PrivateKey = requestSslConfiguration_sslConfiguration_PrivateKey;
                requestSslConfigurationIsNull = false;
            }
             // determine if request.SslConfiguration should be set to null
            if (requestSslConfigurationIsNull)
            {
                request.SslConfiguration = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.OpsWorks.Model.UpdateAppResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.UpdateAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "UpdateApp");
            try
            {
                return client.UpdateAppAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppSource_Password { get; set; }
            public System.String AppSource_Revision { get; set; }
            public System.String AppSource_SshKey { get; set; }
            public Amazon.OpsWorks.SourceType AppSource_Type { get; set; }
            public System.String AppSource_Url { get; set; }
            public System.String AppSource_Username { get; set; }
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public List<Amazon.OpsWorks.Model.DataSource> DataSource { get; set; }
            public System.String Description { get; set; }
            public List<System.String> Domain { get; set; }
            public System.Boolean? EnableSsl { get; set; }
            public List<Amazon.OpsWorks.Model.EnvironmentVariable> Environment { get; set; }
            public System.String Name { get; set; }
            public System.String SslConfiguration_Certificate { get; set; }
            public System.String SslConfiguration_Chain { get; set; }
            public System.String SslConfiguration_PrivateKey { get; set; }
            public Amazon.OpsWorks.AppType Type { get; set; }
            public System.Func<Amazon.OpsWorks.Model.UpdateAppResponse, UpdateOPSAppCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
