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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Places an Object Retention configuration on an object.
    /// </summary>
    [Cmdlet("Write", "S3ObjectRetention", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.RequestCharged")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service PutObjectRetention API operation.", Operation = new[] {"PutObjectRetention"})]
    [AWSCmdletOutput("Amazon.S3.RequestCharged",
        "This cmdlet returns a RequestCharged object.",
        "The service call response (type Amazon.S3.Model.PutObjectRetentionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3ObjectRetentionCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket that contains the object you want to apply this Object Retention configuration
        /// to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter BypassGovernanceRetention
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean BypassGovernanceRetention { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// <para>The MD5 signature for the configuration included in your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The key name for the object that you want to apply this Object Retention configuration
        /// to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter Retention_Mode
        /// <summary>
        /// <para>
        /// <para>Indicates the Retention mode for the specified object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.ObjectLockRetentionMode")]
        public Amazon.S3.ObjectLockRetentionMode Retention_Mode { get; set; }
        #endregion
        
        #region Parameter RequestPayer
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.RequestPayer")]
        public Amazon.S3.RequestPayer RequestPayer { get; set; }
        #endregion
        
        #region Parameter Retention_RetainUntilDate
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime Retention_RetainUntilDate { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>The version ID for the object that you want to apply this Object Retention configuration
        /// to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        
        #endregion
        
        #region Parameter UseDualstackEndpoint
        /// <summary>
        /// Configures the request to Amazon S3 to use the dualstack endpoint for a region.
        /// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.
        /// The dualstack mode of Amazon S3 cannot be used with accelerate mode.
        /// </summary>
        [Parameter]
        public SwitchParameter UseDualstackEndpoint { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3ObjectRetention (PutObjectRetention)"))
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
            
            context.BucketName = this.BucketName;
            if (ParameterWasBound("BypassGovernanceRetention"))
                context.BypassGovernanceRetention = this.BypassGovernanceRetention;
            context.ContentMD5 = this.ContentMD5;
            context.Key = this.Key;
            context.RequestPayer = this.RequestPayer;
            context.Retention_Mode = this.Retention_Mode;
            if (ParameterWasBound("Retention_RetainUntilDate"))
                context.Retention_RetainUntilDate = this.Retention_RetainUntilDate;
            context.VersionId = this.VersionId;
            
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
            var request = new Amazon.S3.Model.PutObjectRetentionRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.BypassGovernanceRetention != null)
            {
                request.BypassGovernanceRetention = cmdletContext.BypassGovernanceRetention.Value;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            
             // populate Retention
            bool requestRetentionIsNull = true;
            request.Retention = new Amazon.S3.Model.ObjectLockRetention();
            Amazon.S3.ObjectLockRetentionMode requestRetention_retention_Mode = null;
            if (cmdletContext.Retention_Mode != null)
            {
                requestRetention_retention_Mode = cmdletContext.Retention_Mode;
            }
            if (requestRetention_retention_Mode != null)
            {
                request.Retention.Mode = requestRetention_retention_Mode;
                requestRetentionIsNull = false;
            }
            System.DateTime? requestRetention_retention_RetainUntilDate = null;
            if (cmdletContext.Retention_RetainUntilDate != null)
            {
                requestRetention_retention_RetainUntilDate = cmdletContext.Retention_RetainUntilDate.Value;
            }
            if (requestRetention_retention_RetainUntilDate != null)
            {
                request.Retention.RetainUntilDate = requestRetention_retention_RetainUntilDate.Value;
                requestRetentionIsNull = false;
            }
             // determine if request.Retention should be set to null
            if (requestRetentionIsNull)
            {
                request.Retention = null;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RequestCharged;
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
        
        private Amazon.S3.Model.PutObjectRetentionResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutObjectRetentionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service", "PutObjectRetention");
            try
            {
                #if DESKTOP
                return client.PutObjectRetention(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutObjectRetentionAsync(request);
                return task.Result;
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
            public System.String BucketName { get; set; }
            public System.Boolean? BypassGovernanceRetention { get; set; }
            public System.String ContentMD5 { get; set; }
            public System.String Key { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public Amazon.S3.ObjectLockRetentionMode Retention_Mode { get; set; }
            public System.DateTime? Retention_RetainUntilDate { get; set; }
            public System.String VersionId { get; set; }
        }
        
    }
}
