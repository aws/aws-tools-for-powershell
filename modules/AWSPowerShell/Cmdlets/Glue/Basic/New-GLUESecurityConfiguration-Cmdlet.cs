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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates a new security configuration. A security configuration is a set of security
    /// properties that can be used by Glue. You can use a security configuration to encrypt
    /// data at rest. For information about using security configurations in Glue, see <a href="https://docs.aws.amazon.com/glue/latest/dg/encryption-security-configuration.html">Encrypting
    /// Data Written by Crawlers, Jobs, and Development Endpoints</a>.
    /// </summary>
    [Cmdlet("New", "GLUESecurityConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.CreateSecurityConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Glue CreateSecurityConfiguration API operation.", Operation = new[] {"CreateSecurityConfiguration"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateSecurityConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.CreateSecurityConfigurationResponse",
        "This cmdlet returns an Amazon.Glue.Model.CreateSecurityConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGLUESecurityConfigurationCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter CloudWatchEncryption_CloudWatchEncryptionMode
        /// <summary>
        /// <para>
        /// <para>The encryption mode to use for CloudWatch data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionConfiguration_CloudWatchEncryption_CloudWatchEncryptionMode")]
        [AWSConstantClassSource("Amazon.Glue.CloudWatchEncryptionMode")]
        public Amazon.Glue.CloudWatchEncryptionMode CloudWatchEncryption_CloudWatchEncryptionMode { get; set; }
        #endregion
        
        #region Parameter JobBookmarksEncryption_JobBookmarksEncryptionMode
        /// <summary>
        /// <para>
        /// <para>The encryption mode to use for job bookmarks data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionConfiguration_JobBookmarksEncryption_JobBookmarksEncryptionMode")]
        [AWSConstantClassSource("Amazon.Glue.JobBookmarksEncryptionMode")]
        public Amazon.Glue.JobBookmarksEncryptionMode JobBookmarksEncryption_JobBookmarksEncryptionMode { get; set; }
        #endregion
        
        #region Parameter CloudWatchEncryption_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key to be used to encrypt the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionConfiguration_CloudWatchEncryption_KmsKeyArn")]
        public System.String CloudWatchEncryption_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter JobBookmarksEncryption_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key to be used to encrypt the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionConfiguration_JobBookmarksEncryption_KmsKeyArn")]
        public System.String JobBookmarksEncryption_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the new security configuration.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_S3Encryption
        /// <summary>
        /// <para>
        /// <para>The encryption configuration for Amazon Simple Storage Service (Amazon S3) data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Glue.Model.S3Encryption[] EncryptionConfiguration_S3Encryption { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateSecurityConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.CreateSecurityConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUESecurityConfiguration (CreateSecurityConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateSecurityConfigurationResponse, NewGLUESecurityConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudWatchEncryption_CloudWatchEncryptionMode = this.CloudWatchEncryption_CloudWatchEncryptionMode;
            context.CloudWatchEncryption_KmsKeyArn = this.CloudWatchEncryption_KmsKeyArn;
            context.JobBookmarksEncryption_JobBookmarksEncryptionMode = this.JobBookmarksEncryption_JobBookmarksEncryptionMode;
            context.JobBookmarksEncryption_KmsKeyArn = this.JobBookmarksEncryption_KmsKeyArn;
            if (this.EncryptionConfiguration_S3Encryption != null)
            {
                context.EncryptionConfiguration_S3Encryption = new List<Amazon.Glue.Model.S3Encryption>(this.EncryptionConfiguration_S3Encryption);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Glue.Model.CreateSecurityConfigurationRequest();
            
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.Glue.Model.EncryptionConfiguration();
            List<Amazon.Glue.Model.S3Encryption> requestEncryptionConfiguration_encryptionConfiguration_S3Encryption = null;
            if (cmdletContext.EncryptionConfiguration_S3Encryption != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_S3Encryption = cmdletContext.EncryptionConfiguration_S3Encryption;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_S3Encryption != null)
            {
                request.EncryptionConfiguration.S3Encryption = requestEncryptionConfiguration_encryptionConfiguration_S3Encryption;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.Glue.Model.CloudWatchEncryption requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption = null;
            
             // populate CloudWatchEncryption
            var requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryptionIsNull = true;
            requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption = new Amazon.Glue.Model.CloudWatchEncryption();
            Amazon.Glue.CloudWatchEncryptionMode requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_CloudWatchEncryptionMode = null;
            if (cmdletContext.CloudWatchEncryption_CloudWatchEncryptionMode != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_CloudWatchEncryptionMode = cmdletContext.CloudWatchEncryption_CloudWatchEncryptionMode;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_CloudWatchEncryptionMode != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption.CloudWatchEncryptionMode = requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_CloudWatchEncryptionMode;
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryptionIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_KmsKeyArn = null;
            if (cmdletContext.CloudWatchEncryption_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_KmsKeyArn = cmdletContext.CloudWatchEncryption_KmsKeyArn;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption.KmsKeyArn = requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_KmsKeyArn;
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryptionIsNull = false;
            }
             // determine if requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption should be set to null
            if (requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryptionIsNull)
            {
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption = null;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption != null)
            {
                request.EncryptionConfiguration.CloudWatchEncryption = requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.Glue.Model.JobBookmarksEncryption requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption = null;
            
             // populate JobBookmarksEncryption
            var requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryptionIsNull = true;
            requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption = new Amazon.Glue.Model.JobBookmarksEncryption();
            Amazon.Glue.JobBookmarksEncryptionMode requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_JobBookmarksEncryptionMode = null;
            if (cmdletContext.JobBookmarksEncryption_JobBookmarksEncryptionMode != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_JobBookmarksEncryptionMode = cmdletContext.JobBookmarksEncryption_JobBookmarksEncryptionMode;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_JobBookmarksEncryptionMode != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption.JobBookmarksEncryptionMode = requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_JobBookmarksEncryptionMode;
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryptionIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_KmsKeyArn = null;
            if (cmdletContext.JobBookmarksEncryption_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_KmsKeyArn = cmdletContext.JobBookmarksEncryption_KmsKeyArn;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption.KmsKeyArn = requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_KmsKeyArn;
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryptionIsNull = false;
            }
             // determine if requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption should be set to null
            if (requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryptionIsNull)
            {
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption = null;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption != null)
            {
                request.EncryptionConfiguration.JobBookmarksEncryption = requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Glue.Model.CreateSecurityConfigurationResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateSecurityConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateSecurityConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateSecurityConfiguration(request);
                #elif CORECLR
                return client.CreateSecurityConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Glue.CloudWatchEncryptionMode CloudWatchEncryption_CloudWatchEncryptionMode { get; set; }
            public System.String CloudWatchEncryption_KmsKeyArn { get; set; }
            public Amazon.Glue.JobBookmarksEncryptionMode JobBookmarksEncryption_JobBookmarksEncryptionMode { get; set; }
            public System.String JobBookmarksEncryption_KmsKeyArn { get; set; }
            public List<Amazon.Glue.Model.S3Encryption> EncryptionConfiguration_S3Encryption { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.Glue.Model.CreateSecurityConfigurationResponse, NewGLUESecurityConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
