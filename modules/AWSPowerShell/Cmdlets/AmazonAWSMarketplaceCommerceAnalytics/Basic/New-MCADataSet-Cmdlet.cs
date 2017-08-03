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
    [AWSCmdlet("Invokes the GenerateDataSet operation against AWS Marketplace Commerce Analytics.", Operation = new[] {"GenerateDataSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMCADataSetCmdlet : AmazonAWSMarketplaceCommerceAnalyticsClientCmdlet, IExecutor
    {
        
        #region Parameter CustomerDefinedValue
        /// <summary>
        /// <para>
        /// (Optional) Key-value pairs which
        /// will be returned, unmodified, in the Amazon SNS notification message and the data
        /// set metadata file. These key-value pairs can be used to correlated responses with
        /// tracking information from other systems.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CustomerDefinedValues")]
        public System.Collections.Hashtable CustomerDefinedValue { get; set; }
        #endregion
        
        #region Parameter DataSetPublicationDate
        /// <summary>
        /// <para>
        /// The date a data set was published.
        /// For daily data sets, provide a date with day-level granularity for the desired day.
        /// For weekly data sets, provide a date with day-level granularity within the desired
        /// week (the day value will be ignored). For monthly data sets, provide a date with month-level
        /// granularity for the desired month (the day value will be ignored).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime DataSetPublicationDate { get; set; }
        #endregion
        
        #region Parameter DataSetType
        /// <summary>
        /// <para>
        /// <para>The desired data set type.</para><para><ul><li><strong>customer_subscriber_hourly_monthly_subscriptions</strong><para>From 2014-07-21 to present: Available daily by 5:00 PM Pacific Time.</para></li><li><strong>customer_subscriber_annual_subscriptions</strong><para>From 2014-07-21 to present: Available daily by 5:00 PM Pacific Time.</para></li><li><strong>daily_business_usage_by_instance_type</strong><para>From 2015-01-26 to present: Available daily by 5:00 PM Pacific Time.</para></li><li><strong>daily_business_fees</strong><para>From 2015-01-26 to present: Available daily by 5:00 PM Pacific Time.</para></li><li><strong>daily_business_free_trial_conversions</strong><para>From 2015-01-26 to present: Available daily by 5:00 PM Pacific Time.</para></li><li><strong>daily_business_new_instances</strong><para>From 2015-01-26 to present: Available daily by 5:00 PM Pacific Time.</para></li><li><strong>daily_business_new_product_subscribers</strong><para>From 2015-01-26 to present: Available daily by 5:00 PM Pacific Time.</para></li><li><strong>daily_business_canceled_product_subscribers</strong><para>From 2015-01-26 to present: Available daily by 5:00 PM Pacific Time.</para></li><li><strong>monthly_revenue_billing_and_revenue_data</strong><para>From 2015-02 to 2017-06: Available monthly on the 4th day of the month by 5:00pm Pacific
        /// Time. Data includes metered transactions (e.g. hourly) from two months prior.</para><para>From 2017-07 to present: Available monthly on the 15th day of the month by 5:00pm
        /// Pacific Time. Data includes metered transactions (e.g. hourly) from one month prior.</para></li><li><strong>monthly_revenue_annual_subscriptions</strong><para>From 2015-02 to 2017-06: Available monthly on the 4th day of the month by 5:00pm Pacific
        /// Time. Data includes up-front software charges (e.g. annual) from one month prior.</para><para>From 2017-07 to present: Available monthly on the 15th day of the month by 5:00pm
        /// Pacific Time. Data includes up-front software charges (e.g. annual) from one month
        /// prior.</para></li><li><strong>disbursed_amount_by_product</strong><para>From 2015-01-26 to present: Available every 30 days by 5:00 PM Pacific Time.</para></li><li><strong>disbursed_amount_by_product_with_uncollected_funds</strong><para>From 2012-04-19 to 2015-01-25: Available every 30 days by 5:00 PM Pacific Time.</para><para>From 2015-01-26 to present: This data set was split into three data sets: disbursed_amount_by_product,
        /// disbursed_amount_by_age_of_uncollected_funds, and disbursed_amount_by_age_of_disbursed_funds.</para></li><li><strong>disbursed_amount_by_instance_hours</strong><para>From 2012-09-04 to present: Available every 30 days by 5:00 PM Pacific Time.</para></li><li><strong>disbursed_amount_by_customer_geo</strong><para>From 2012-04-19 to present: Available every 30 days by 5:00 PM Pacific Time.</para></li><li><strong>disbursed_amount_by_age_of_uncollected_funds</strong><para>From 2015-01-26 to present: Available every 30 days by 5:00 PM Pacific Time.</para></li><li><strong>disbursed_amount_by_age_of_disbursed_funds</strong><para>From 2015-01-26 to present: Available every 30 days by 5:00 PM Pacific Time.</para></li><li><strong>customer_profile_by_industry</strong><para>From 2015-10-01 to 2017-06-29: Available daily by 5:00 PM Pacific Time.</para><para>From 2017-06-30 to present: This data set is no longer available.</para></li><li><strong>customer_profile_by_revenue</strong><para>From 2015-10-01 to 2017-06-29: Available daily by 5:00 PM Pacific Time.</para><para>From 2017-06-30 to present: This data set is no longer available.</para></li><li><strong>customer_profile_by_geography</strong><para>From 2015-10-01 to 2017-06-29: Available daily by 5:00 PM Pacific Time.</para><para>From 2017-06-30 to present: This data set is no longer available.</para></li><li><strong>sales_compensation_billed_revenue</strong><para>From 2016-12 to 2017-06: Available monthly on the 4th day of the month by 5:00pm Pacific
        /// Time. Data includes metered transactions (e.g. hourly) from two months prior, and
        /// up-front software charges (e.g. annual) from one month prior.</para><para>From 2017-06 to present: Available monthly on the 15th day of the month by 5:00pm
        /// Pacific Time. Data includes metered transactions (e.g. hourly) from one month prior,
        /// and up-front software charges (e.g. annual) from one month prior.</para></li><li><strong>us_sales_and_use_tax_records</strong><para>From 2017-02-15 to present: Available monthly on the 15th day of the month by 5:00
        /// PM Pacific Time.</para></li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter(Position = 1)]
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
        [System.Management.Automation.Parameter]
        public System.String DestinationS3Prefix { get; set; }
        #endregion
        
        #region Parameter RoleNameArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the Role
        /// with an attached permissions policy to interact with the provided AWS services.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String RoleNameArn { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// Amazon Resource Name (ARN) for the SNS Topic
        /// that will be notified when the data set has been published or if an error has occurred.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String SnsTopicArn { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.CustomerDefinedValue != null)
            {
                context.CustomerDefinedValues = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomerDefinedValue.Keys)
                {
                    context.CustomerDefinedValues.Add((String)hashKey, (String)(this.CustomerDefinedValue[hashKey]));
                }
            }
            if (ParameterWasBound("DataSetPublicationDate"))
                context.DataSetPublicationDate = this.DataSetPublicationDate;
            context.DataSetType = this.DataSetType;
            context.DestinationS3BucketName = this.DestinationS3BucketName;
            context.DestinationS3Prefix = this.DestinationS3Prefix;
            context.RoleNameArn = this.RoleNameArn;
            context.SnsTopicArn = this.SnsTopicArn;
            
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
            
            if (cmdletContext.CustomerDefinedValues != null)
            {
                request.CustomerDefinedValues = cmdletContext.CustomerDefinedValues;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DataSetRequestId;
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
        
        private Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetResponse CallAWSServiceOperation(IAmazonAWSMarketplaceCommerceAnalytics client, Amazon.AWSMarketplaceCommerceAnalytics.Model.GenerateDataSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Commerce Analytics", "GenerateDataSet");
            #if DESKTOP
            return client.GenerateDataSet(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GenerateDataSetAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, System.String> CustomerDefinedValues { get; set; }
            public System.DateTime? DataSetPublicationDate { get; set; }
            public Amazon.AWSMarketplaceCommerceAnalytics.DataSetType DataSetType { get; set; }
            public System.String DestinationS3BucketName { get; set; }
            public System.String DestinationS3Prefix { get; set; }
            public System.String RoleNameArn { get; set; }
            public System.String SnsTopicArn { get; set; }
        }
        
    }
}
