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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates a new security configuration.
    /// </summary>
    [Cmdlet("New", "GLUESecurityConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.CreateSecurityConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Glue CreateSecurityConfiguration API operation.", Operation = new[] {"CreateSecurityConfiguration"})]
    [AWSCmdletOutput("Amazon.Glue.Model.CreateSecurityConfigurationResponse",
        "This cmdlet returns a Amazon.Glue.Model.CreateSecurityConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGLUESecurityConfigurationCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter CloudWatchEncryption_CloudWatchEncryptionMode
        /// <summary>
        /// <para>
        /// <para>The encryption mode to use for CloudWatch data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EncryptionConfiguration_CloudWatchEncryption_CloudWatchEncryptionMode")]
        [AWSConstantClassSource("Amazon.Glue.CloudWatchEncryptionMode")]
        public Amazon.Glue.CloudWatchEncryptionMode CloudWatchEncryption_CloudWatchEncryptionMode { get; set; }
        #endregion
        
        #region Parameter JobBookmarksEncryption_JobBookmarksEncryptionMode
        /// <summary>
        /// <para>
        /// <para>The encryption mode to use for Job bookmarks data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EncryptionConfiguration_JobBookmarksEncryption_JobBookmarksEncryptionMode")]
        [AWSConstantClassSource("Amazon.Glue.JobBookmarksEncryptionMode")]
        public Amazon.Glue.JobBookmarksEncryptionMode JobBookmarksEncryption_JobBookmarksEncryptionMode { get; set; }
        #endregion
        
        #region Parameter CloudWatchEncryption_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The AWS ARN of the KMS key to be used to encrypt the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EncryptionConfiguration_CloudWatchEncryption_KmsKeyArn")]
        public System.String CloudWatchEncryption_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter JobBookmarksEncryption_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The AWS ARN of the KMS key to be used to encrypt the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EncryptionConfiguration_JobBookmarksEncryption_KmsKeyArn")]
        public System.String JobBookmarksEncryption_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the new security configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_S3Encryption
        /// <summary>
        /// <para>
        /// <para>The encryption configuration for S3 data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Glue.Model.S3Encryption[] EncryptionConfiguration_S3Encryption { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUESecurityConfiguration (CreateSecurityConfiguration)"))
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
            
            context.EncryptionConfiguration_CloudWatchEncryption_CloudWatchEncryptionMode = this.CloudWatchEncryption_CloudWatchEncryptionMode;
            context.EncryptionConfiguration_CloudWatchEncryption_KmsKeyArn = this.CloudWatchEncryption_KmsKeyArn;
            context.EncryptionConfiguration_JobBookmarksEncryption_JobBookmarksEncryptionMode = this.JobBookmarksEncryption_JobBookmarksEncryptionMode;
            context.EncryptionConfiguration_JobBookmarksEncryption_KmsKeyArn = this.JobBookmarksEncryption_KmsKeyArn;
            if (this.EncryptionConfiguration_S3Encryption != null)
            {
                context.EncryptionConfiguration_S3Encryption = new List<Amazon.Glue.Model.S3Encryption>(this.EncryptionConfiguration_S3Encryption);
            }
            context.Name = this.Name;
            
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
            bool requestEncryptionConfigurationIsNull = true;
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
            bool requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryptionIsNull = true;
            requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption = new Amazon.Glue.Model.CloudWatchEncryption();
            Amazon.Glue.CloudWatchEncryptionMode requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_CloudWatchEncryptionMode = null;
            if (cmdletContext.EncryptionConfiguration_CloudWatchEncryption_CloudWatchEncryptionMode != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_CloudWatchEncryptionMode = cmdletContext.EncryptionConfiguration_CloudWatchEncryption_CloudWatchEncryptionMode;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_CloudWatchEncryptionMode != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption.CloudWatchEncryptionMode = requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_CloudWatchEncryptionMode;
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryptionIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_CloudWatchEncryption_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_CloudWatchEncryption_cloudWatchEncryption_KmsKeyArn = cmdletContext.EncryptionConfiguration_CloudWatchEncryption_KmsKeyArn;
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
            bool requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryptionIsNull = true;
            requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption = new Amazon.Glue.Model.JobBookmarksEncryption();
            Amazon.Glue.JobBookmarksEncryptionMode requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_JobBookmarksEncryptionMode = null;
            if (cmdletContext.EncryptionConfiguration_JobBookmarksEncryption_JobBookmarksEncryptionMode != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_JobBookmarksEncryptionMode = cmdletContext.EncryptionConfiguration_JobBookmarksEncryption_JobBookmarksEncryptionMode;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_JobBookmarksEncryptionMode != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption.JobBookmarksEncryptionMode = requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_JobBookmarksEncryptionMode;
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryptionIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_JobBookmarksEncryption_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_JobBookmarksEncryption_jobBookmarksEncryption_KmsKeyArn = cmdletContext.EncryptionConfiguration_JobBookmarksEncryption_KmsKeyArn;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
            public Amazon.Glue.CloudWatchEncryptionMode EncryptionConfiguration_CloudWatchEncryption_CloudWatchEncryptionMode { get; set; }
            public System.String EncryptionConfiguration_CloudWatchEncryption_KmsKeyArn { get; set; }
            public Amazon.Glue.JobBookmarksEncryptionMode EncryptionConfiguration_JobBookmarksEncryption_JobBookmarksEncryptionMode { get; set; }
            public System.String EncryptionConfiguration_JobBookmarksEncryption_KmsKeyArn { get; set; }
            public List<Amazon.Glue.Model.S3Encryption> EncryptionConfiguration_S3Encryption { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
