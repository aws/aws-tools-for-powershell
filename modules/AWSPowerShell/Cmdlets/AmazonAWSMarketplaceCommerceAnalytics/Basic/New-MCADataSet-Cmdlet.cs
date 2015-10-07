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
    /// s3:PutObject, s3:getBucketLocation, sns:SetRegion, sns:ListTopics, sns:Publish, iam:GetRolePolicy.
    /// </summary>
    [Cmdlet("New", "MCADataSet")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the GenerateDataSet operation against AWS Marketplace Commerce Analytics.", Operation = new[] {"GenerateDataSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type GenerateDataSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewMCADataSetCmdlet : AmazonAWSMarketplaceCommerceAnalyticsClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime DataSetPublicationDate { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DataSetType DataSetType { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String DestinationS3BucketName { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DestinationS3Prefix { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String RoleNameArn { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public String SnsTopicArn { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("DataSetPublicationDate"))
                context.DataSetPublicationDate = this.DataSetPublicationDate;
            context.DataSetType = this.DataSetType;
            context.DestinationS3BucketName = this.DestinationS3BucketName;
            context.DestinationS3Prefix = this.DestinationS3Prefix;
            context.RoleNameArn = this.RoleNameArn;
            context.SnsTopicArn = this.SnsTopicArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GenerateDataSetRequest();
            
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
                var response = client.GenerateDataSet(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public DateTime? DataSetPublicationDate { get; set; }
            public DataSetType DataSetType { get; set; }
            public String DestinationS3BucketName { get; set; }
            public String DestinationS3Prefix { get; set; }
            public String RoleNameArn { get; set; }
            public String SnsTopicArn { get; set; }
        }
        
    }
}
