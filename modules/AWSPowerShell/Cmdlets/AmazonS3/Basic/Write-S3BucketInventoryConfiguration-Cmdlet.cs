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
    /// Adds an inventory configuration (identified by the inventory ID) from the bucket.
    /// </summary>
    [Cmdlet("Write", "S3BucketInventoryConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutBucketInventoryConfiguration operation against Amazon Simple Storage Service.", Operation = new[] {"PutBucketInventoryConfiguration"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the BucketName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.S3.Model.PutBucketInventoryConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3BucketInventoryConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter S3BucketDestination_AccountId
        /// <summary>
        /// <para>
        /// The ID of the account that owns the destination bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InventoryConfiguration_Destination_S3BucketDestination_AccountId")]
        public System.String S3BucketDestination_AccountId { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket where the inventory configuration will be stored.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_BucketName
        /// <summary>
        /// <para>
        /// The Amazon resource name (ARN) of the bucket where inventory results will be published.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InventoryConfiguration_Destination_S3BucketDestination_BucketName")]
        public System.String S3BucketDestination_BucketName { get; set; }
        #endregion
        
        #region Parameter Schedule_Frequency
        /// <summary>
        /// <para>
        /// Specifies how frequently inventory results are produced.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InventoryConfiguration_Schedule_Frequency")]
        [AWSConstantClassSource("Amazon.S3.InventoryFrequency")]
        public Amazon.S3.InventoryFrequency Schedule_Frequency { get; set; }
        #endregion
        
        #region Parameter InventoryConfiguration_IncludedObjectVersion
        /// <summary>
        /// <para>
        /// Specifies which object version(s) to included in the inventory results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InventoryConfiguration_IncludedObjectVersions")]
        [AWSConstantClassSource("Amazon.S3.InventoryIncludedObjectVersions")]
        public Amazon.S3.InventoryIncludedObjectVersions InventoryConfiguration_IncludedObjectVersion { get; set; }
        #endregion
        
        #region Parameter InventoryFilter_InventoryFilterPredicate
        /// <summary>
        /// <para>
        /// Filter Predicate setup for specific filter types.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InventoryConfiguration_InventoryFilter_InventoryFilterPredicate")]
        public Amazon.S3.Model.InventoryFilterPredicate InventoryFilter_InventoryFilterPredicate { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_InventoryFormat
        /// <summary>
        /// <para>
        /// Specifies the output format of the inventory results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InventoryConfiguration_Destination_S3BucketDestination_InventoryFormat")]
        [AWSConstantClassSource("Amazon.S3.InventoryFormat")]
        public Amazon.S3.InventoryFormat S3BucketDestination_InventoryFormat { get; set; }
        #endregion
        
        #region Parameter InventoryId
        /// <summary>
        /// <para>
        /// Specifies the inventory Id.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InventoryId { get; set; }
        #endregion
        
        #region Parameter InventoryConfiguration_InventoryId
        /// <summary>
        /// <para>
        /// The ID used to identify the inventory configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InventoryConfiguration_InventoryId { get; set; }
        #endregion
        
        #region Parameter InventoryConfiguration_InventoryOptionalField
        /// <summary>
        /// <para>
        /// Contains the optional fields that are included in the inventory results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InventoryConfiguration_InventoryOptionalFields")]
        public Amazon.S3.InventoryOptionalField[] InventoryConfiguration_InventoryOptionalField { get; set; }
        #endregion
        
        #region Parameter InventoryConfiguration_IsEnabled
        /// <summary>
        /// <para>
        /// Specifies whether the inventory is enabled or disabled.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean InventoryConfiguration_IsEnabled { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_Prefix
        /// <summary>
        /// <para>
        /// The prefix that is prepended to all inventory results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InventoryConfiguration_Destination_S3BucketDestination_Prefix")]
        public System.String S3BucketDestination_Prefix { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketInventoryConfiguration (PutBucketInventoryConfiguration)"))
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
            context.InventoryId = this.InventoryId;
            context.InventoryConfiguration_Destination_S3BucketDestination_AccountId = this.S3BucketDestination_AccountId;
            context.InventoryConfiguration_Destination_S3BucketDestination_BucketName = this.S3BucketDestination_BucketName;
            context.InventoryConfiguration_Destination_S3BucketDestination_Prefix = this.S3BucketDestination_Prefix;
            context.InventoryConfiguration_Destination_S3BucketDestination_InventoryFormat = this.S3BucketDestination_InventoryFormat;
            if (ParameterWasBound("InventoryConfiguration_IsEnabled"))
                context.InventoryConfiguration_IsEnabled = this.InventoryConfiguration_IsEnabled;
            context.InventoryConfiguration_InventoryFilter_InventoryFilterPredicate = this.InventoryFilter_InventoryFilterPredicate;
            context.InventoryConfiguration_InventoryId = this.InventoryConfiguration_InventoryId;
            context.InventoryConfiguration_IncludedObjectVersions = this.InventoryConfiguration_IncludedObjectVersion;
            if (this.InventoryConfiguration_InventoryOptionalField != null)
            {
                context.InventoryConfiguration_InventoryOptionalFields = new List<Amazon.S3.InventoryOptionalField>(this.InventoryConfiguration_InventoryOptionalField);
            }
            context.InventoryConfiguration_Schedule_Frequency = this.Schedule_Frequency;
            
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
            var request = new Amazon.S3.Model.PutBucketInventoryConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.InventoryId != null)
            {
                request.InventoryId = cmdletContext.InventoryId;
            }
            
             // populate InventoryConfiguration
            bool requestInventoryConfigurationIsNull = true;
            request.InventoryConfiguration = new Amazon.S3.Model.InventoryConfiguration();
            System.Boolean? requestInventoryConfiguration_inventoryConfiguration_IsEnabled = null;
            if (cmdletContext.InventoryConfiguration_IsEnabled != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_IsEnabled = cmdletContext.InventoryConfiguration_IsEnabled.Value;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_IsEnabled != null)
            {
                request.InventoryConfiguration.IsEnabled = requestInventoryConfiguration_inventoryConfiguration_IsEnabled.Value;
                requestInventoryConfigurationIsNull = false;
            }
            System.String requestInventoryConfiguration_inventoryConfiguration_InventoryId = null;
            if (cmdletContext.InventoryConfiguration_InventoryId != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_InventoryId = cmdletContext.InventoryConfiguration_InventoryId;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_InventoryId != null)
            {
                request.InventoryConfiguration.InventoryId = requestInventoryConfiguration_inventoryConfiguration_InventoryId;
                requestInventoryConfigurationIsNull = false;
            }
            Amazon.S3.InventoryIncludedObjectVersions requestInventoryConfiguration_inventoryConfiguration_IncludedObjectVersion = null;
            if (cmdletContext.InventoryConfiguration_IncludedObjectVersions != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_IncludedObjectVersion = cmdletContext.InventoryConfiguration_IncludedObjectVersions;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_IncludedObjectVersion != null)
            {
                request.InventoryConfiguration.IncludedObjectVersions = requestInventoryConfiguration_inventoryConfiguration_IncludedObjectVersion;
                requestInventoryConfigurationIsNull = false;
            }
            List<Amazon.S3.InventoryOptionalField> requestInventoryConfiguration_inventoryConfiguration_InventoryOptionalField = null;
            if (cmdletContext.InventoryConfiguration_InventoryOptionalFields != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_InventoryOptionalField = cmdletContext.InventoryConfiguration_InventoryOptionalFields;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_InventoryOptionalField != null)
            {
                request.InventoryConfiguration.InventoryOptionalFields = requestInventoryConfiguration_inventoryConfiguration_InventoryOptionalField;
                requestInventoryConfigurationIsNull = false;
            }
            Amazon.S3.Model.InventoryDestination requestInventoryConfiguration_inventoryConfiguration_Destination = null;
            
             // populate Destination
            bool requestInventoryConfiguration_inventoryConfiguration_DestinationIsNull = true;
            requestInventoryConfiguration_inventoryConfiguration_Destination = new Amazon.S3.Model.InventoryDestination();
            Amazon.S3.Model.InventoryS3BucketDestination requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination = null;
            
             // populate S3BucketDestination
            bool requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = true;
            requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination = new Amazon.S3.Model.InventoryS3BucketDestination();
            System.String requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_AccountId = null;
            if (cmdletContext.InventoryConfiguration_Destination_S3BucketDestination_AccountId != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_AccountId = cmdletContext.InventoryConfiguration_Destination_S3BucketDestination_AccountId;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_AccountId != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination.AccountId = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_AccountId;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = false;
            }
            System.String requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_BucketName = null;
            if (cmdletContext.InventoryConfiguration_Destination_S3BucketDestination_BucketName != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_BucketName = cmdletContext.InventoryConfiguration_Destination_S3BucketDestination_BucketName;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_BucketName != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination.BucketName = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_BucketName;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = false;
            }
            System.String requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_Prefix = null;
            if (cmdletContext.InventoryConfiguration_Destination_S3BucketDestination_Prefix != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_Prefix = cmdletContext.InventoryConfiguration_Destination_S3BucketDestination_Prefix;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_Prefix != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination.Prefix = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_Prefix;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = false;
            }
            Amazon.S3.InventoryFormat requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_InventoryFormat = null;
            if (cmdletContext.InventoryConfiguration_Destination_S3BucketDestination_InventoryFormat != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_InventoryFormat = cmdletContext.InventoryConfiguration_Destination_S3BucketDestination_InventoryFormat;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_InventoryFormat != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination.InventoryFormat = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_InventoryFormat;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = false;
            }
             // determine if requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination should be set to null
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination = null;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination.S3BucketDestination = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination;
                requestInventoryConfiguration_inventoryConfiguration_DestinationIsNull = false;
            }
             // determine if requestInventoryConfiguration_inventoryConfiguration_Destination should be set to null
            if (requestInventoryConfiguration_inventoryConfiguration_DestinationIsNull)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination = null;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination != null)
            {
                request.InventoryConfiguration.Destination = requestInventoryConfiguration_inventoryConfiguration_Destination;
                requestInventoryConfigurationIsNull = false;
            }
            Amazon.S3.Model.InventoryFilter requestInventoryConfiguration_inventoryConfiguration_InventoryFilter = null;
            
             // populate InventoryFilter
            bool requestInventoryConfiguration_inventoryConfiguration_InventoryFilterIsNull = true;
            requestInventoryConfiguration_inventoryConfiguration_InventoryFilter = new Amazon.S3.Model.InventoryFilter();
            Amazon.S3.Model.InventoryFilterPredicate requestInventoryConfiguration_inventoryConfiguration_InventoryFilter_inventoryFilter_InventoryFilterPredicate = null;
            if (cmdletContext.InventoryConfiguration_InventoryFilter_InventoryFilterPredicate != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_InventoryFilter_inventoryFilter_InventoryFilterPredicate = cmdletContext.InventoryConfiguration_InventoryFilter_InventoryFilterPredicate;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_InventoryFilter_inventoryFilter_InventoryFilterPredicate != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_InventoryFilter.InventoryFilterPredicate = requestInventoryConfiguration_inventoryConfiguration_InventoryFilter_inventoryFilter_InventoryFilterPredicate;
                requestInventoryConfiguration_inventoryConfiguration_InventoryFilterIsNull = false;
            }
             // determine if requestInventoryConfiguration_inventoryConfiguration_InventoryFilter should be set to null
            if (requestInventoryConfiguration_inventoryConfiguration_InventoryFilterIsNull)
            {
                requestInventoryConfiguration_inventoryConfiguration_InventoryFilter = null;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_InventoryFilter != null)
            {
                request.InventoryConfiguration.InventoryFilter = requestInventoryConfiguration_inventoryConfiguration_InventoryFilter;
                requestInventoryConfigurationIsNull = false;
            }
            Amazon.S3.Model.InventorySchedule requestInventoryConfiguration_inventoryConfiguration_Schedule = null;
            
             // populate Schedule
            bool requestInventoryConfiguration_inventoryConfiguration_ScheduleIsNull = true;
            requestInventoryConfiguration_inventoryConfiguration_Schedule = new Amazon.S3.Model.InventorySchedule();
            Amazon.S3.InventoryFrequency requestInventoryConfiguration_inventoryConfiguration_Schedule_schedule_Frequency = null;
            if (cmdletContext.InventoryConfiguration_Schedule_Frequency != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Schedule_schedule_Frequency = cmdletContext.InventoryConfiguration_Schedule_Frequency;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Schedule_schedule_Frequency != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Schedule.Frequency = requestInventoryConfiguration_inventoryConfiguration_Schedule_schedule_Frequency;
                requestInventoryConfiguration_inventoryConfiguration_ScheduleIsNull = false;
            }
             // determine if requestInventoryConfiguration_inventoryConfiguration_Schedule should be set to null
            if (requestInventoryConfiguration_inventoryConfiguration_ScheduleIsNull)
            {
                requestInventoryConfiguration_inventoryConfiguration_Schedule = null;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Schedule != null)
            {
                request.InventoryConfiguration.Schedule = requestInventoryConfiguration_inventoryConfiguration_Schedule;
                requestInventoryConfigurationIsNull = false;
            }
             // determine if request.InventoryConfiguration should be set to null
            if (requestInventoryConfigurationIsNull)
            {
                request.InventoryConfiguration = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.S3.Model.PutBucketInventoryConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketInventoryConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service", "PutBucketInventoryConfiguration");
            try
            {
                #if DESKTOP
                return client.PutBucketInventoryConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutBucketInventoryConfigurationAsync(request);
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
            public System.String InventoryId { get; set; }
            public System.String InventoryConfiguration_Destination_S3BucketDestination_AccountId { get; set; }
            public System.String InventoryConfiguration_Destination_S3BucketDestination_BucketName { get; set; }
            public System.String InventoryConfiguration_Destination_S3BucketDestination_Prefix { get; set; }
            public Amazon.S3.InventoryFormat InventoryConfiguration_Destination_S3BucketDestination_InventoryFormat { get; set; }
            public System.Boolean? InventoryConfiguration_IsEnabled { get; set; }
            public Amazon.S3.Model.InventoryFilterPredicate InventoryConfiguration_InventoryFilter_InventoryFilterPredicate { get; set; }
            public System.String InventoryConfiguration_InventoryId { get; set; }
            public Amazon.S3.InventoryIncludedObjectVersions InventoryConfiguration_IncludedObjectVersions { get; set; }
            public List<Amazon.S3.InventoryOptionalField> InventoryConfiguration_InventoryOptionalFields { get; set; }
            public Amazon.S3.InventoryFrequency InventoryConfiguration_Schedule_Frequency { get; set; }
        }
        
    }
}
