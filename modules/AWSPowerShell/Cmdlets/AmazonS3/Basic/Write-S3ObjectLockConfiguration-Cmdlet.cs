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
    /// Places an Object Lock configuration on the specified bucket. The rule specified in
    /// the Object Lock configuration will be applied by default to every new object placed
    /// in the specified bucket.
    /// </summary>
    [Cmdlet("Write", "S3ObjectLockConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.RequestCharged")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service PutObjectLockConfiguration API operation.", Operation = new[] {"PutObjectLockConfiguration"})]
    [AWSCmdletOutput("Amazon.S3.RequestCharged",
        "This cmdlet returns a RequestCharged object.",
        "The service call response (type Amazon.S3.Model.PutObjectLockConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3ObjectLockConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket whose Object Lock configuration you want to create or replace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
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
        
        #region Parameter DefaultRetention_Day
        /// <summary>
        /// <para>
        /// <para>The number of days that you want to specify for the default retention period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ObjectLockConfiguration_Rule_DefaultRetention_Days")]
        public System.Int32 DefaultRetention_Day { get; set; }
        #endregion
        
        #region Parameter DefaultRetention_Mode
        /// <summary>
        /// <para>
        /// <para>The default Object Lock retention mode you want to apply to new objects placed in
        /// the specified bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ObjectLockConfiguration_Rule_DefaultRetention_Mode")]
        [AWSConstantClassSource("Amazon.S3.ObjectLockRetentionMode")]
        public Amazon.S3.ObjectLockRetentionMode DefaultRetention_Mode { get; set; }
        #endregion
        
        #region Parameter ObjectLockConfiguration_ObjectLockEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether this object has an Object Lock configuration enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.ObjectLockEnabled")]
        public Amazon.S3.ObjectLockEnabled ObjectLockConfiguration_ObjectLockEnabled { get; set; }
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
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Token { get; set; }
        #endregion
        
        #region Parameter DefaultRetention_Year
        /// <summary>
        /// <para>
        /// <para>The number of years that you want to specify for the default retention period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ObjectLockConfiguration_Rule_DefaultRetention_Years")]
        public System.Int32 DefaultRetention_Year { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3ObjectLockConfiguration (PutObjectLockConfiguration)"))
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
            context.ContentMD5 = this.ContentMD5;
            context.ObjectLockConfiguration_ObjectLockEnabled = this.ObjectLockConfiguration_ObjectLockEnabled;
            if (ParameterWasBound("DefaultRetention_Day"))
                context.ObjectLockConfiguration_Rule_DefaultRetention_Days = this.DefaultRetention_Day;
            context.ObjectLockConfiguration_Rule_DefaultRetention_Mode = this.DefaultRetention_Mode;
            if (ParameterWasBound("DefaultRetention_Year"))
                context.ObjectLockConfiguration_Rule_DefaultRetention_Years = this.DefaultRetention_Year;
            context.RequestPayer = this.RequestPayer;
            context.Token = this.Token;
            
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
            var request = new Amazon.S3.Model.PutObjectLockConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            
             // populate ObjectLockConfiguration
            bool requestObjectLockConfigurationIsNull = true;
            request.ObjectLockConfiguration = new Amazon.S3.Model.ObjectLockConfiguration();
            Amazon.S3.ObjectLockEnabled requestObjectLockConfiguration_objectLockConfiguration_ObjectLockEnabled = null;
            if (cmdletContext.ObjectLockConfiguration_ObjectLockEnabled != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_ObjectLockEnabled = cmdletContext.ObjectLockConfiguration_ObjectLockEnabled;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_ObjectLockEnabled != null)
            {
                request.ObjectLockConfiguration.ObjectLockEnabled = requestObjectLockConfiguration_objectLockConfiguration_ObjectLockEnabled;
                requestObjectLockConfigurationIsNull = false;
            }
            Amazon.S3.Model.ObjectLockRule requestObjectLockConfiguration_objectLockConfiguration_Rule = null;
            
             // populate Rule
            bool requestObjectLockConfiguration_objectLockConfiguration_RuleIsNull = true;
            requestObjectLockConfiguration_objectLockConfiguration_Rule = new Amazon.S3.Model.ObjectLockRule();
            Amazon.S3.Model.DefaultRetention requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention = null;
            
             // populate DefaultRetention
            bool requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetentionIsNull = true;
            requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention = new Amazon.S3.Model.DefaultRetention();
            System.Int32? requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Day = null;
            if (cmdletContext.ObjectLockConfiguration_Rule_DefaultRetention_Days != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Day = cmdletContext.ObjectLockConfiguration_Rule_DefaultRetention_Days.Value;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Day != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention.Days = requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Day.Value;
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetentionIsNull = false;
            }
            Amazon.S3.ObjectLockRetentionMode requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Mode = null;
            if (cmdletContext.ObjectLockConfiguration_Rule_DefaultRetention_Mode != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Mode = cmdletContext.ObjectLockConfiguration_Rule_DefaultRetention_Mode;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Mode != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention.Mode = requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Mode;
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetentionIsNull = false;
            }
            System.Int32? requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Year = null;
            if (cmdletContext.ObjectLockConfiguration_Rule_DefaultRetention_Years != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Year = cmdletContext.ObjectLockConfiguration_Rule_DefaultRetention_Years.Value;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Year != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention.Years = requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention_defaultRetention_Year.Value;
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetentionIsNull = false;
            }
             // determine if requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention should be set to null
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetentionIsNull)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention = null;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention != null)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule.DefaultRetention = requestObjectLockConfiguration_objectLockConfiguration_Rule_objectLockConfiguration_Rule_DefaultRetention;
                requestObjectLockConfiguration_objectLockConfiguration_RuleIsNull = false;
            }
             // determine if requestObjectLockConfiguration_objectLockConfiguration_Rule should be set to null
            if (requestObjectLockConfiguration_objectLockConfiguration_RuleIsNull)
            {
                requestObjectLockConfiguration_objectLockConfiguration_Rule = null;
            }
            if (requestObjectLockConfiguration_objectLockConfiguration_Rule != null)
            {
                request.ObjectLockConfiguration.Rule = requestObjectLockConfiguration_objectLockConfiguration_Rule;
                requestObjectLockConfigurationIsNull = false;
            }
             // determine if request.ObjectLockConfiguration should be set to null
            if (requestObjectLockConfigurationIsNull)
            {
                request.ObjectLockConfiguration = null;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            if (cmdletContext.Token != null)
            {
                request.Token = cmdletContext.Token;
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
        
        private Amazon.S3.Model.PutObjectLockConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutObjectLockConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service", "PutObjectLockConfiguration");
            try
            {
                #if DESKTOP
                return client.PutObjectLockConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutObjectLockConfigurationAsync(request);
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
            public System.String ContentMD5 { get; set; }
            public Amazon.S3.ObjectLockEnabled ObjectLockConfiguration_ObjectLockEnabled { get; set; }
            public System.Int32? ObjectLockConfiguration_Rule_DefaultRetention_Days { get; set; }
            public Amazon.S3.ObjectLockRetentionMode ObjectLockConfiguration_Rule_DefaultRetention_Mode { get; set; }
            public System.Int32? ObjectLockConfiguration_Rule_DefaultRetention_Years { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String Token { get; set; }
        }
        
    }
}
