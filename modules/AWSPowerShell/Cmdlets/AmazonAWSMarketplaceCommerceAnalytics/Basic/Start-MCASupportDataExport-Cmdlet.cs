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
    /// Given a data set type and a from date, asynchronously publishes the requested customer
    /// support data to the specified S3 bucket and notifies the specified SNS topic once
    /// the data is available. Returns a unique request identifier that can be used to correlate
    /// requests with notifications from the SNS topic. Data sets will be published in comma-separated
    /// values (CSV) format with the file name {data_set_type}_YYYY-MM-DD'T'HH-mm-ss'Z'.csv.
    /// If a file with the same name already exists (e.g. if the same data set is requested
    /// twice), the original file will be overwritten by the new file. Requires a Role with
    /// an attached permissions policy providing Allow permissions for the following actions:
    /// s3:PutObject, s3:GetBucketLocation, sns:GetTopicAttributes, sns:Publish, iam:GetRolePolicy.
    /// </summary>
    [Cmdlet("Start", "MCASupportDataExport")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the StartSupportDataExport operation against AWS Marketplace Commerce Analytics.", Operation = new[] {"StartSupportDataExport"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartMCASupportDataExportCmdlet : AmazonAWSMarketplaceCommerceAnalyticsClientCmdlet, IExecutor
    {
        
        #region Parameter CustomerDefinedValue
        /// <summary>
        /// <para>
        /// (Optional) Key-value pairs which
        /// will be returned, unmodified, in the Amazon SNS notification message and the data
        /// set metadata file.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CustomerDefinedValues")]
        public System.Collections.Hashtable CustomerDefinedValue { get; set; }
        #endregion
        
        #region Parameter DataSetType
        /// <summary>
        /// <para>
        /// <para> Specifies the data set type to be written to the output csv file. The data set types
        /// customer_support_contacts_data and test_customer_support_contacts_data both result
        /// in a csv file containing the following fields: Product Id, Product Code, Customer
        /// Guid, Subscription Guid, Subscription Start Date, Organization, AWS Account Id, Given
        /// Name, Surname, Telephone Number, Email, Title, Country Code, ZIP Code, Operation Type,
        /// and Operation Time. </para><para><ul><li><i>customer_support_contacts_data</i> Customer support contact data. The
        /// data set will contain all changes (Creates, Updates, and Deletes) to customer support
        /// contact data from the date specified in the from_date parameter.</li><li><i>test_customer_support_contacts_data</i>
        /// An example data set containing static test data in the same format as customer_support_contacts_data</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AWSMarketplaceCommerceAnalytics.SupportDataSetType")]
        public Amazon.AWSMarketplaceCommerceAnalytics.SupportDataSetType DataSetType { get; set; }
        #endregion
        
        #region Parameter DestinationS3BucketName
        /// <summary>
        /// <para>
        /// The name (friendly name, not ARN)
        /// of the destination S3 bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        
        #region Parameter FromDate
        /// <summary>
        /// <para>
        /// The start date from which to retrieve the data
        /// set in UTC. This parameter only affects the customer_support_contacts_data data set
        /// type.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime FromDate { get; set; }
        #endregion
        
        #region Parameter RoleNameArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the Role
        /// with an attached permissions policy to interact with the provided AWS services.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleNameArn { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// Amazon Resource Name (ARN) for the SNS Topic
        /// that will be notified when the data set has been published or if an error has occurred.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
            context.DataSetType = this.DataSetType;
            context.DestinationS3BucketName = this.DestinationS3BucketName;
            context.DestinationS3Prefix = this.DestinationS3Prefix;
            if (ParameterWasBound("FromDate"))
                context.FromDate = this.FromDate;
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
            var request = new Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportRequest();
            
            if (cmdletContext.CustomerDefinedValues != null)
            {
                request.CustomerDefinedValues = cmdletContext.CustomerDefinedValues;
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
            if (cmdletContext.FromDate != null)
            {
                request.FromDate = cmdletContext.FromDate.Value;
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
        
        private static Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportResponse CallAWSServiceOperation(IAmazonAWSMarketplaceCommerceAnalytics client, Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportRequest request)
        {
            #if DESKTOP
            return client.StartSupportDataExport(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.StartSupportDataExportAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, System.String> CustomerDefinedValues { get; set; }
            public Amazon.AWSMarketplaceCommerceAnalytics.SupportDataSetType DataSetType { get; set; }
            public System.String DestinationS3BucketName { get; set; }
            public System.String DestinationS3Prefix { get; set; }
            public System.DateTime? FromDate { get; set; }
            public System.String RoleNameArn { get; set; }
            public System.String SnsTopicArn { get; set; }
        }
        
    }
}
