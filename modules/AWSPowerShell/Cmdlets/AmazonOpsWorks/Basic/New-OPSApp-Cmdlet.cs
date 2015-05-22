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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Creates an app for a specified stack. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingapps-creating.html">Creating
    /// Apps</a>.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OPSApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateApp operation against AWS OpsWorks.", Operation = new[] {"CreateApp"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type CreateAppResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewOPSAppCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more user-defined key/value pairs to be added to the stack attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The contents of the certificate's domain.crt file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SslConfiguration_Certificate { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Optional. Can be used to specify an intermediate certificate authority key or client
        /// authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SslConfiguration_Chain { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The app's data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataSources")]
        public Amazon.OpsWorks.Model.DataSource[] DataSource { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A description of the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The app virtual host settings, with multiple domains separated by commas. For example:
        /// <code>'www.example.com, example.com'</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Domains")]
        public System.String[] Domain { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to enable SSL for the app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean EnableSsl { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of <code>EnvironmentVariable</code> objects that specify environment variables
        /// to be associated with the app. After you deploy the app, these variables are defined
        /// on the associated app server instance. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingapps-creating.html#workingapps-creating-environment">
        /// Environment Variables</a>.</para><para> There is no specific limit on the number of environment variables. However, the size
        /// of the associated data structure - which includes the variables' names, values, and
        /// protected flag values - cannot exceed 10 KB (10240 Bytes). This limit should accommodate
        /// most if not all use cases. Exceeding it will cause an exception with the message,
        /// "Environment: is too large (maximum is 10KB)." </para><note>This parameter is supported only by Chef 11.10 stacks. If you have specified
        /// one or more environment variables, you cannot modify the stack's Chef version.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.OpsWorks.Model.EnvironmentVariable[] Environment { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The app name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>When included in a request, the parameter depends on the repository type. </para><ul><li>For Amazon S3 bundles, set <code>Password</code> to the appropriate IAM
        /// secret access key.</li><li>For HTTP bundles and Subversion repositories, set <code>Password</code>
        /// to the password.</li></ul><para>For more information on how to safely handle IAM credentials, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html"></a>.</para><para>In responses, AWS OpsWorks returns <code>*****FILTERED*****</code> instead of the
        /// actual value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AppSource_Password { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The private key; the contents of the certificate's domain.kex file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SslConfiguration_PrivateKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The application's version. AWS OpsWorks enables you to easily deploy new versions
        /// of an application. One of the simplest approaches is to have branches or revisions
        /// in your repository that represent different versions that can potentially be deployed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AppSource_Revision { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The app's short name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String Shortname { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>In requests, the repository's SSH key.</para><para>In responses, AWS OpsWorks returns <code>*****FILTERED*****</code> instead of the
        /// actual value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AppSource_SshKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The stack ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String StackId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The repository type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public SourceType AppSource_Type { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The app type. Each supported type is associated with a particular layer. For example,
        /// PHP applications are associated with a PHP layer. AWS OpsWorks deploys an application
        /// to those instances that are members of the corresponding layer. If your app isn't
        /// one of the standard types, or you prefer to implement your own Deploy recipes, specify
        /// <code>other</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public AppType Type { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The source URL. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AppSource_Url { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>This parameter depends on the repository type. </para><ul><li>For Amazon S3 bundles, set <code>Username</code> to the appropriate IAM
        /// access key ID.</li><li>For HTTP bundles, Git repositories, and Subversion repositories,
        /// set <code>Username</code> to the user name.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AppSource_Username { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OPSApp (CreateApp)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AppSource_Password = this.AppSource_Password;
            context.AppSource_Revision = this.AppSource_Revision;
            context.AppSource_SshKey = this.AppSource_SshKey;
            context.AppSource_Type = this.AppSource_Type;
            context.AppSource_Url = this.AppSource_Url;
            context.AppSource_Username = this.AppSource_Username;
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            if (this.DataSource != null)
            {
                context.DataSources = new List<DataSource>(this.DataSource);
            }
            context.Description = this.Description;
            if (this.Domain != null)
            {
                context.Domains = new List<String>(this.Domain);
            }
            if (ParameterWasBound("EnableSsl"))
                context.EnableSsl = this.EnableSsl;
            if (this.Environment != null)
            {
                context.Environment = new List<EnvironmentVariable>(this.Environment);
            }
            context.Name = this.Name;
            context.Shortname = this.Shortname;
            context.SslConfiguration_Certificate = this.SslConfiguration_Certificate;
            context.SslConfiguration_Chain = this.SslConfiguration_Chain;
            context.SslConfiguration_PrivateKey = this.SslConfiguration_PrivateKey;
            context.StackId = this.StackId;
            context.Type = this.Type;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateAppRequest();
            
            
             // populate AppSource
            bool requestAppSourceIsNull = true;
            request.AppSource = new Source();
            String requestAppSource_appSource_Password = null;
            if (cmdletContext.AppSource_Password != null)
            {
                requestAppSource_appSource_Password = cmdletContext.AppSource_Password;
            }
            if (requestAppSource_appSource_Password != null)
            {
                request.AppSource.Password = requestAppSource_appSource_Password;
                requestAppSourceIsNull = false;
            }
            String requestAppSource_appSource_Revision = null;
            if (cmdletContext.AppSource_Revision != null)
            {
                requestAppSource_appSource_Revision = cmdletContext.AppSource_Revision;
            }
            if (requestAppSource_appSource_Revision != null)
            {
                request.AppSource.Revision = requestAppSource_appSource_Revision;
                requestAppSourceIsNull = false;
            }
            String requestAppSource_appSource_SshKey = null;
            if (cmdletContext.AppSource_SshKey != null)
            {
                requestAppSource_appSource_SshKey = cmdletContext.AppSource_SshKey;
            }
            if (requestAppSource_appSource_SshKey != null)
            {
                request.AppSource.SshKey = requestAppSource_appSource_SshKey;
                requestAppSourceIsNull = false;
            }
            SourceType requestAppSource_appSource_Type = null;
            if (cmdletContext.AppSource_Type != null)
            {
                requestAppSource_appSource_Type = cmdletContext.AppSource_Type;
            }
            if (requestAppSource_appSource_Type != null)
            {
                request.AppSource.Type = requestAppSource_appSource_Type;
                requestAppSourceIsNull = false;
            }
            String requestAppSource_appSource_Url = null;
            if (cmdletContext.AppSource_Url != null)
            {
                requestAppSource_appSource_Url = cmdletContext.AppSource_Url;
            }
            if (requestAppSource_appSource_Url != null)
            {
                request.AppSource.Url = requestAppSource_appSource_Url;
                requestAppSourceIsNull = false;
            }
            String requestAppSource_appSource_Username = null;
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
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            if (cmdletContext.DataSources != null)
            {
                request.DataSources = cmdletContext.DataSources;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Domains != null)
            {
                request.Domains = cmdletContext.Domains;
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
            if (cmdletContext.Shortname != null)
            {
                request.Shortname = cmdletContext.Shortname;
            }
            
             // populate SslConfiguration
            bool requestSslConfigurationIsNull = true;
            request.SslConfiguration = new SslConfiguration();
            String requestSslConfiguration_sslConfiguration_Certificate = null;
            if (cmdletContext.SslConfiguration_Certificate != null)
            {
                requestSslConfiguration_sslConfiguration_Certificate = cmdletContext.SslConfiguration_Certificate;
            }
            if (requestSslConfiguration_sslConfiguration_Certificate != null)
            {
                request.SslConfiguration.Certificate = requestSslConfiguration_sslConfiguration_Certificate;
                requestSslConfigurationIsNull = false;
            }
            String requestSslConfiguration_sslConfiguration_Chain = null;
            if (cmdletContext.SslConfiguration_Chain != null)
            {
                requestSslConfiguration_sslConfiguration_Chain = cmdletContext.SslConfiguration_Chain;
            }
            if (requestSslConfiguration_sslConfiguration_Chain != null)
            {
                request.SslConfiguration.Chain = requestSslConfiguration_sslConfiguration_Chain;
                requestSslConfigurationIsNull = false;
            }
            String requestSslConfiguration_sslConfiguration_PrivateKey = null;
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
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateApp(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AppId;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String AppSource_Password { get; set; }
            public String AppSource_Revision { get; set; }
            public String AppSource_SshKey { get; set; }
            public SourceType AppSource_Type { get; set; }
            public String AppSource_Url { get; set; }
            public String AppSource_Username { get; set; }
            public Dictionary<String, String> Attributes { get; set; }
            public List<DataSource> DataSources { get; set; }
            public String Description { get; set; }
            public List<String> Domains { get; set; }
            public Boolean? EnableSsl { get; set; }
            public List<EnvironmentVariable> Environment { get; set; }
            public String Name { get; set; }
            public String Shortname { get; set; }
            public String SslConfiguration_Certificate { get; set; }
            public String SslConfiguration_Chain { get; set; }
            public String SslConfiguration_PrivateKey { get; set; }
            public String StackId { get; set; }
            public AppType Type { get; set; }
        }
        
    }
}
