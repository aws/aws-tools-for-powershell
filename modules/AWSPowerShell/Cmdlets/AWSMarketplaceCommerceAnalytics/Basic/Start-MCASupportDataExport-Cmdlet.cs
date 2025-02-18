/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.AWSMarketplaceCommerceAnalytics;
using Amazon.AWSMarketplaceCommerceAnalytics.Model;

namespace Amazon.PowerShell.Cmdlets.MCA
{
    /// <summary>
    /// <i>This target has been deprecated.</i> Given a data set type and a from date, asynchronously
    /// publishes the requested customer support data to the specified S3 bucket and notifies
    /// the specified SNS topic once the data is available. Returns a unique request identifier
    /// that can be used to correlate requests with notifications from the SNS topic. Data
    /// sets will be published in comma-separated values (CSV) format with the file name {data_set_type}_YYYY-MM-DD'T'HH-mm-ss'Z'.csv.
    /// If a file with the same name already exists (e.g. if the same data set is requested
    /// twice), the original file will be overwritten by the new file. Requires a Role with
    /// an attached permissions policy providing Allow permissions for the following actions:
    /// s3:PutObject, s3:GetBucketLocation, sns:GetTopicAttributes, sns:Publish, iam:GetRolePolicy.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Start", "MCASupportDataExport")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Marketplace Commerce Analytics StartSupportDataExport API operation.", Operation = new[] {"StartSupportDataExport"}, SelectReturnType = typeof(Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportResponse))]
    [AWSCmdletOutput("System.String or Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This target has been deprecated. As of December 2022 Product Support Connection is no longer supported.")]
    public partial class StartMCASupportDataExportCmdlet : AmazonAWSMarketplaceCommerceAnalyticsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CustomerDefinedValue
        /// <summary>
        /// <para>
        /// <i>This target has been deprecated.</i>
        /// (Optional) Key-value pairs which will be returned, unmodified, in the Amazon SNS notification
        /// message and the data set metadata file.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomerDefinedValues")]
        public System.Collections.Hashtable CustomerDefinedValue { get; set; }
        #endregion
        
        #region Parameter DataSetType
        /// <summary>
        /// <para>
        /// <para><i>This target has been deprecated.</i> Specifies the data set type to be written
        /// to the output csv file. The data set types customer_support_contacts_data and test_customer_support_contacts_data
        /// both result in a csv file containing the following fields: Product Id, Product Code,
        /// Customer Guid, Subscription Guid, Subscription Start Date, Organization, AWS Account
        /// Id, Given Name, Surname, Telephone Number, Email, Title, Country Code, ZIP Code, Operation
        /// Type, and Operation Time. </para><para><ul><li><i>customer_support_contacts_data</i> Customer support contact data. The
        /// data set will contain all changes (Creates, Updates, and Deletes) to customer support
        /// contact data from the date specified in the from_date parameter.</li><li><i>test_customer_support_contacts_data</i>
        /// An example data set containing static test data in the same format as customer_support_contacts_data</li></ul></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AWSMarketplaceCommerceAnalytics.SupportDataSetType")]
        public Amazon.AWSMarketplaceCommerceAnalytics.SupportDataSetType DataSetType { get; set; }
        #endregion
        
        #region Parameter DestinationS3BucketName
        /// <summary>
        /// <para>
        /// <i>This target has been deprecated.</i>
        /// The name (friendly name, not ARN) of the destination S3 bucket.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DestinationS3BucketName { get; set; }
        #endregion
        
        #region Parameter DestinationS3Prefix
        /// <summary>
        /// <para>
        /// <i>This target has been deprecated.</i>
        /// (Optional) The desired S3 prefix for the published data set, similar to a directory
        /// path in standard file systems. For example, if given the bucket name "mybucket" and
        /// the prefix "myprefix/mydatasets", the output file "outputfile" would be published
        /// to "s3://mybucket/myprefix/mydatasets/outputfile". If the prefix directory structure
        /// does not exist, it will be created. If no prefix is provided, the data set will be
        /// published to the S3 bucket root.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationS3Prefix { get; set; }
        #endregion
        
        #region Parameter FromDate
        /// <summary>
        /// <para>
        /// <i>This target has been deprecated.</i> The start
        /// date from which to retrieve the data set in UTC. This parameter only affects the customer_support_contacts_data
        /// data set type.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? FromDate { get; set; }
        #endregion
        
        #region Parameter RoleNameArn
        /// <summary>
        /// <para>
        /// <i>This target has been deprecated.</i> The
        /// Amazon Resource Name (ARN) of the Role with an attached permissions policy to interact
        /// with the provided AWS services.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RoleNameArn { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <i>This target has been deprecated.</i> Amazon
        /// Resource Name (ARN) for the SNS Topic that will be notified when the data set has
        /// been published or if an error has occurred.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataSetRequestId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportResponse).
        /// Specifying the name of a property of type Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataSetRequestId";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportResponse, StartMCASupportDataExportCmdlet>(Select) ??
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
            context.FromDate = this.FromDate;
            #if MODULAR
            if (this.FromDate == null && ParameterWasBound(nameof(this.FromDate)))
            {
                WriteWarning("You are passing $null as a value for parameter FromDate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportRequest();
            
            if (cmdletContext.CustomerDefinedValue != null)
            {
                request.CustomerDefinedValues = cmdletContext.CustomerDefinedValue;
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
        
        private Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportResponse CallAWSServiceOperation(IAmazonAWSMarketplaceCommerceAnalytics client, Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Commerce Analytics", "StartSupportDataExport");
            try
            {
                return client.StartSupportDataExportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.AWSMarketplaceCommerceAnalytics.SupportDataSetType DataSetType { get; set; }
            public System.String DestinationS3BucketName { get; set; }
            public System.String DestinationS3Prefix { get; set; }
            public System.DateTime? FromDate { get; set; }
            public System.String RoleNameArn { get; set; }
            public System.String SnsTopicArn { get; set; }
            public System.Func<Amazon.AWSMarketplaceCommerceAnalytics.Model.StartSupportDataExportResponse, StartMCASupportDataExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataSetRequestId;
        }
        
    }
}
