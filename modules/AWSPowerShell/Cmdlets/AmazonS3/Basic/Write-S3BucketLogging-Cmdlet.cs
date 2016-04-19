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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Set the logging parameters for a bucket and to specify permissions for who can view
    /// and modify the logging parameters. To set the logging status of a bucket, you must
    /// be the bucket owner.
    /// </summary>
    [Cmdlet("Write", "S3BucketLogging", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutBucketLogging operation against Amazon Simple Storage Service.", Operation = new[] {"PutBucketLogging"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the BucketName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.S3.Model.PutBucketLoggingResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteS3BucketLoggingCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_Grant
        /// <summary>
        /// <para>
        /// A collection of grants.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LoggingConfig_Grants")]
        public Amazon.S3.Model.S3Grant[] LoggingConfig_Grant { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_TargetBucketName
        /// <summary>
        /// <para>
        /// Specifies the bucket where you want Amazon S3 to store server access logs. You can have your logs delivered to any bucket that you own,
        /// including the same bucket that is being logged. You can also configure multiple buckets to deliver their logs to the same target bucket. In
        /// this case you should choose a different TargetPrefix for each source bucket so that the delivered log files can be distinguished by key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LoggingConfig_TargetBucketName { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_TargetPrefix
        /// <summary>
        /// <para>
        /// This element lets you specify a prefix for the keys that the log files will be stored under.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LoggingConfig_TargetPrefix { get; set; }
        #endregion
        
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the BucketName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BucketName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketLogging (PutBucketLogging)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.BucketName = this.BucketName;
            context.LoggingConfig_TargetBucketName = this.LoggingConfig_TargetBucketName;
            if (this.LoggingConfig_Grant != null)
            {
                context.LoggingConfig_Grants = new List<Amazon.S3.Model.S3Grant>(this.LoggingConfig_Grant);
            }
            context.LoggingConfig_TargetPrefix = this.LoggingConfig_TargetPrefix;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.S3.Model.PutBucketLoggingRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            
             // populate LoggingConfig
            bool requestLoggingConfigIsNull = true;
            request.LoggingConfig = new Amazon.S3.Model.S3BucketLoggingConfig();
            System.String requestLoggingConfig_loggingConfig_TargetBucketName = null;
            if (cmdletContext.LoggingConfig_TargetBucketName != null)
            {
                requestLoggingConfig_loggingConfig_TargetBucketName = cmdletContext.LoggingConfig_TargetBucketName;
            }
            if (requestLoggingConfig_loggingConfig_TargetBucketName != null)
            {
                request.LoggingConfig.TargetBucketName = requestLoggingConfig_loggingConfig_TargetBucketName;
                requestLoggingConfigIsNull = false;
            }
            List<Amazon.S3.Model.S3Grant> requestLoggingConfig_loggingConfig_Grant = null;
            if (cmdletContext.LoggingConfig_Grants != null)
            {
                requestLoggingConfig_loggingConfig_Grant = cmdletContext.LoggingConfig_Grants;
            }
            if (requestLoggingConfig_loggingConfig_Grant != null)
            {
                request.LoggingConfig.Grants = requestLoggingConfig_loggingConfig_Grant;
                requestLoggingConfigIsNull = false;
            }
            System.String requestLoggingConfig_loggingConfig_TargetPrefix = null;
            if (cmdletContext.LoggingConfig_TargetPrefix != null)
            {
                requestLoggingConfig_loggingConfig_TargetPrefix = cmdletContext.LoggingConfig_TargetPrefix;
            }
            if (requestLoggingConfig_loggingConfig_TargetPrefix != null)
            {
                request.LoggingConfig.TargetPrefix = requestLoggingConfig_loggingConfig_TargetPrefix;
                requestLoggingConfigIsNull = false;
            }
             // determine if request.LoggingConfig should be set to null
            if (requestLoggingConfigIsNull)
            {
                request.LoggingConfig = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutBucketLogging(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.BucketName;
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
            public System.String BucketName { get; set; }
            public System.String LoggingConfig_TargetBucketName { get; set; }
            public List<Amazon.S3.Model.S3Grant> LoggingConfig_Grants { get; set; }
            public System.String LoggingConfig_TargetPrefix { get; set; }
        }
        
    }
}
