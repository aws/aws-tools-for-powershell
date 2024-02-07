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
using Amazon.AWSMarketplaceCommerceAnalytics;
using Amazon.AWSMarketplaceCommerceAnalytics.Model;

namespace Amazon.PowerShell.Cmdlets.MCA
{
    /// <summary>
    /// Given a data set type and data set publication date, asynchronously publishes the
    /// requested data set to the specified S3 bucket and notifies the specified SNS topic
    /// once the data is available. Returns a unique request identifier that can be used to
    /// correlate requests with notifications from the SNS topic. Data sets will be published
    /// in comma-separated values (CSV) format with the file name {data_set_type}_YYYY-MM-DD.csv.
    /// If a file with the same name already exists (e.g. if the same data set is requested
    /// twice), the original file will be overwritten by the new file. Requires a Role with
    /// an attached permissions policy providing Allow permissions for the following actions:
    /// s3:PutObject, s3:GetBucketLocation, sns:GetTopicAttributes, sns:Publish, iam:GetRolePolicy.
    /// </summary>
    [Cmdlet("New", "MCADataSet")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Marketplace Commerce Analytics GenerateDataSet API operation.", Operation = new[] {"GenerateDataSet"}, SelectReturnType = typeof(Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMCADataSetCmdlet : AmazonAWSMarketplaceCommerceAnalyticsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomerDefinedValue
        /// <summary>
        /// <para>
        /// (Optional) Key-value pairs which
        /// will be returned, unmodified, in the Amazon SNS notification message and the data
        /// set metadata file. These key-value pairs can be used to correlated responses with
        /// tracking information from other systems.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomerDefinedValues")]
        public System.Collections.Hashtable CustomerDefinedValue { get; set; }
        #endregion
        
        #region Parameter DataSetPublicationDate
        /// <summary>
        /// <para>
        /// The date a data set was published.
        /// For daily data sets, provide a date with day-level granularity for the desired day.
        /// For monthly data sets except those with prefix disbursed_amount, provide a date with
        /// month-level granularity for the desired month (the day value will be ignored). For
        /// data sets with prefix disbursed_amount, provide a date with day-level granularity
        /// for the desired day. For these data sets we will look backwards in time over the range
        /// of 31 days until the first data set is found (the latest one).
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? DataSetPublicationDate { get; set; }
        #endregion
        
        #region Parameter DataSetType
        /// <summary>
        /// <para>
        /// <para>The desired data set type.</para><para><ul><li><strong>customer_subscriber_hourly_monthly_subscriptions</strong><para>From 2017-09-15 to present: Available daily by 24:00 UTC.</para></li><li><strong>customer_subscriber_annual_subscriptions</strong><para>From 2017-09-15 to present: Available daily by 24:00 UTC.</para></li><li><strong>daily_business_usage_by_instance_type</strong><para>From 2017-09-15 to present: Available daily by 24:00 UTC.</para></li><li><strong>daily_business_fees</strong><para>From 2017-09-15 to present: Available daily by 24:00 UTC.</para></li><li><strong>daily_business_free_trial_conversions</strong><para>From 2017-09-15 to present: Available daily by 24:00 UTC.</para></li><li><strong>daily_business_new_instances</strong><para>From 2017-09-15 to present: Available daily by 24:00 UTC.</para></li><li><strong>daily_business_new_product_subscribers</strong><para>From 2017-09-15 to present: Available daily by 24:00 UTC.</para></li><li><strong>daily_business_canceled_product_subscribers</strong><para>From 2017-09-15 to present: Available daily by 24:00 UTC.</para></li><li><strong>monthly_revenue_billing_and_revenue_data</strong><para>From 2017-09-15 to present: Available monthly on the 15th day of the month by 24:00
        /// UTC. Data includes metered transactions (e.g. hourly) from one month prior.</para></li><li><strong>monthly_revenue_annual_subscriptions</strong><para>From 2017-09-15 to present: Available monthly on the 15th day of the month by 24:00
        /// UTC. Data includes up-front software charges (e.g. annual) from one month prior.</para></li><li><strong>monthly_revenue_field_demonstration_usage</strong><para>From 2018-03-15 to present: Available monthly on the 15th day of the month by 24:00
        /// UTC.</para></li><li><strong>monthly_revenue_flexible_payment_schedule</strong><para>From 2018-11-15 to present: Available monthly on the 15th day of the month by 24:00
        /// UTC.</para></li><li><strong>disbursed_amount_by_product</strong><para>From 2017-09-15 to present: Available every 30 days by 24:00 UTC.</para></li><li><strong>disbursed_amount_by_instance_hours</strong><para>From 2017-09-15 to present: Available every 30 days by 24:00 UTC.</para></li><li><strong>disbursed_amount_by_customer_geo</strong><para>From 2017-09-15 to present: Available every 30 days by 24:00 UTC.</para></li><li><strong>disbursed_amount_by_age_of_uncollected_funds</strong><para>From 2017-09-15 to present: Available every 30 days by 24:00 UTC.</para></li><li><strong>disbursed_amount_by_age_of_disbursed_funds</strong><para>From 2017-09-15 to present: Available every 30 days by 24:00 UTC.</para></li><li><strong>disbursed_amount_by_age_of_past_due_funds</strong><para>From 2018-04-07 to present: Available every 30 days by 24:00 UTC.</para></li><li><strong>disbursed_amount_by_uncollected_funds_breakdown</strong><para>From 2019-10-04 to present: Available every 30 days by 24:00 UTC.</para></li><li><strong>sales_compensation_billed_revenue</strong><para>From 2017-09-15 to present: Available monthly on the 15th day of the month by 24:00
        /// UTC. Data includes metered transactions (e.g. hourly) from one month prior, and up-front
        /// software charges (e.g. annual) from one month prior.</para></li><li><strong>us_sales_and_use_tax_records</strong><para>From 2017-09-15 to present: Available monthly on the 15th day of the month by 24:00
        /// UTC.</para></li><li><strong>disbursed_amount_by_product_with_uncollected_funds</strong><para>This data set is deprecated. Download related reports from AMMP instead!</para></li><li><strong>customer_profile_by_industry</strong><para>This data set is deprecated. Download related reports from AMMP instead!</para></li><li><strong>customer_profile_by_revenue</strong><para>This data set is deprecated. Download related reports from AMMP instead!</para></li><li><strong>customer_profile_by_geography</strong><para>This data set is deprecated. Download related reports from AMMP instead!</para></li></ul></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AWSMarketplaceCommerceAnalytics.DataSetType")]
        public Amazon.AWSMarketplaceCommerceAnalytics.DataSetType DataSetType { get; set; }
        #endregion
        
        #region Parameter DestinationS3BucketName
        /// <summary>
        /// <para>
        /// The name (friendly name, not ARN)
        /// of the destination S3 bucket.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DestinationS3BucketName { get; set; }
        #endregion
        
        #region Parameter DestinationS3Prefix
        /// <summary>
        /// <para>
        /// (Optional) The desired S3 prefix for
        /// the published data set, similar to a directory path in standard file systems. For
        /// example, if given the bucket name "mybucket" and the prefix "myprefix/mydatasets",
        /// the output file "outputfile" would be published to "s3://mybucket/myprefix/mydatasets/outputfile".
        /// If the prefix directory structure does not exist, it will be created. If no prefix
        /// is provided, the data set will be published to the S3 bucket root.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationS3Prefix { get; set; }
        #endregion
        
        #region Parameter RoleNameArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the Role
        /// with an attached permissions policy to interact with the provided AWS services.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RoleNameArn { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// Amazon Resource Name (ARN) for the SNS Topic
        /// that will be notified when the data set has been published or if an error has occurred.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataSetRequestId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetResponse).
        /// Specifying the name of a property of type Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataSetRequestId";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetResponse, NewMCADataSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CustomerDefinedValue != null)
            {
                context.CustomerDefinedValue = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomerDefinedValue.Keys)
                {
                    context.CustomerDefinedValue.Add((String)hashKey, (System.String)(this.CustomerDefinedValue[hashKey]));
                }
            }
            context.DataSetPublicationDate = this.DataSetPublicationDate;
            #if MODULAR
            if (this.DataSetPublicationDate == null && ParameterWasBound(nameof(this.DataSetPublicationDate)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSetPublicationDate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSetType = this.DataSetType;
            #if MODULAR
            if (this.DataSetType == null && ParameterWasBound(nameof(this.DataSetType)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationS3BucketName = this.DestinationS3BucketName;
            #if MODULAR
            if (this.DestinationS3BucketName == null && ParameterWasBound(nameof(this.DestinationS3BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationS3BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationS3Prefix = this.DestinationS3Prefix;
            context.RoleNameArn = this.RoleNameArn;
            #if MODULAR
            if (this.RoleNameArn == null && ParameterWasBound(nameof(this.RoleNameArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleNameArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnsTopicArn = this.SnsTopicArn;
            #if MODULAR
            if (this.SnsTopicArn == null && ParameterWasBound(nameof(this.SnsTopicArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SnsTopicArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetRequest();
            
            if (cmdletContext.CustomerDefinedValue != null)
            {
                request.CustomerDefinedValues = cmdletContext.CustomerDefinedValue;
            }
            if (cmdletContext.DataSetPublicationDate != null)
            {
                request.DataSetPublicationDate = cmdletContext.DataSetPublicationDate.Value;
            }
            if (cmdletContext.DataSetType != null)
            {
                request.DataSetType = cmdletContext.DataSetType;
            }
            if (cmdletContext.DestinationS3BucketName != null)
            {
                request.DestinationS3BucketName = cmdletContext.DestinationS3BucketName;
            }
            if (cmdletContext.DestinationS3Prefix != null)
            {
                request.DestinationS3Prefix = cmdletContext.DestinationS3Prefix;
            }
            if (cmdletContext.RoleNameArn != null)
            {
                request.RoleNameArn = cmdletContext.RoleNameArn;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArn = cmdletContext.SnsTopicArn;
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
        
        private Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetResponse CallAWSServiceOperation(IAmazonAWSMarketplaceCommerceAnalytics client, Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Commerce Analytics", "GenerateDataSet");
            try
            {
                #if DESKTOP
                return client.GenerateDataSet(request);
                #elif CORECLR
                return client.GenerateDataSetAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> CustomerDefinedValue { get; set; }
            public System.DateTime? DataSetPublicationDate { get; set; }
            public Amazon.AWSMarketplaceCommerceAnalytics.DataSetType DataSetType { get; set; }
            public System.String DestinationS3BucketName { get; set; }
            public System.String DestinationS3Prefix { get; set; }
            public System.String RoleNameArn { get; set; }
            public System.String SnsTopicArn { get; set; }
            public System.Func<Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetResponse, NewMCADataSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataSetRequestId;
        }
        
    }
}
