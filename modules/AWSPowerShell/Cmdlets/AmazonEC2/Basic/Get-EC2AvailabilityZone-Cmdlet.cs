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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes one or more of the Availability Zones that are available to you. The results
    /// include zones only for the region you're currently using. If there is an event impacting
    /// an Availability Zone, you can use this request to view the state and any provided
    /// message for that Availability Zone.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-regions-availability-zones.html">Regions
    /// and Availability Zones</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2AvailabilityZone")]
    [OutputType("Amazon.EC2.Model.AvailabilityZone")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeAvailabilityZones API operation.", Operation = new[] {"DescribeAvailabilityZones"})]
    [AWSCmdletOutput("Amazon.EC2.Model.AvailabilityZone",
        "This cmdlet returns a collection of AvailabilityZone objects.",
        "The service call response (type Amazon.EC2.Model.DescribeAvailabilityZonesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2AvailabilityZoneCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>message</code> - Information about the Availability Zone.</para></li><li><para><code>region-name</code> - The name of the region for the Availability Zone (for
        /// example, <code>us-east-1</code>).</para></li><li><para><code>state</code> - The state of the Availability Zone (<code>available</code> |
        /// <code>information</code> | <code>impaired</code> | <code>unavailable</code>).</para></li><li><para><code>zone-id</code> - The ID of the Availability Zone (for example, <code>use1-az1</code>).</para></li><li><para><code>zone-name</code> - The name of the Availability Zone (for example, <code>us-east-1a</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ZoneId
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more Availability Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ZoneIds")]
        public System.String[] ZoneId { get; set; }
        #endregion
        
        #region Parameter ZoneName
        /// <summary>
        /// <para>
        /// <para>The names of one or more Availability Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ZoneNames")]
        public System.String[] ZoneName { get; set; }
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
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.ZoneId != null)
            {
                context.ZoneIds = new List<System.String>(this.ZoneId);
            }
            if (this.ZoneName != null)
            {
                context.ZoneNames = new List<System.String>(this.ZoneName);
            }
            
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
            var request = new Amazon.EC2.Model.DescribeAvailabilityZonesRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.ZoneIds != null)
            {
                request.ZoneIds = cmdletContext.ZoneIds;
            }
            if (cmdletContext.ZoneNames != null)
            {
                request.ZoneNames = cmdletContext.ZoneNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AvailabilityZones;
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
        
        private Amazon.EC2.Model.DescribeAvailabilityZonesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeAvailabilityZonesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeAvailabilityZones");
            try
            {
                #if DESKTOP
                return client.DescribeAvailabilityZones(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeAvailabilityZonesAsync(request);
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
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public List<System.String> ZoneIds { get; set; }
            public List<System.String> ZoneNames { get; set; }
        }
        
    }
}
