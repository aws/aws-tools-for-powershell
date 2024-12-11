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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the Availability Zones, Local Zones, and Wavelength Zones that are available
    /// to you. If there is an event impacting a zone, you can use this request to view the
    /// state and any provided messages for that zone.
    /// 
    ///  
    /// <para>
    /// For more information about Availability Zones, Local Zones, and Wavelength Zones,
    /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-regions-availability-zones.html">Regions
    /// and zones</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><note><para>
    /// The order of the elements in the response, including those within nested structures,
    /// might vary. Applications should not assume the elements appear in a particular order.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "EC2AvailabilityZone")]
    [OutputType("Amazon.EC2.Model.AvailabilityZone")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeAvailabilityZones API operation.", Operation = new[] {"DescribeAvailabilityZones"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeAvailabilityZonesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.AvailabilityZone or Amazon.EC2.Model.DescribeAvailabilityZonesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.AvailabilityZone objects.",
        "The service call response (type Amazon.EC2.Model.DescribeAvailabilityZonesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2AvailabilityZoneCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Include all Availability Zones, Local Zones, and Wavelength Zones regardless of your
        /// opt-in status.</para><para>If you do not use this parameter, the results include only the zones for the Regions
        /// where you have chosen the option to opt in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllAvailabilityZones")]
        public System.Boolean? AllAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>group-name</c> - For Availability Zones, use the Region name. For Local Zones,
        /// use the name of the group associated with the Local Zone (for example, <c>us-west-2-lax-1</c>)
        /// For Wavelength Zones, use the name of the group associated with the Wavelength Zone
        /// (for example, <c>us-east-1-wl1</c>).</para></li><li><para><c>message</c> - The Zone message.</para></li><li><para><c>opt-in-status</c> - The opt-in status (<c>opted-in</c> | <c>not-opted-in</c> |
        /// <c>opt-in-not-required</c>).</para></li><li><para><c>parent-zone-id</c> - The ID of the zone that handles some of the Local Zone and
        /// Wavelength Zone control plane operations, such as API calls.</para></li><li><para><c>parent-zone-name</c> - The ID of the zone that handles some of the Local Zone
        /// and Wavelength Zone control plane operations, such as API calls.</para></li><li><para><c>region-name</c> - The name of the Region for the Zone (for example, <c>us-east-1</c>).</para></li><li><para><c>state</c> - The state of the Availability Zone, the Local Zone, or the Wavelength
        /// Zone (<c>available</c>).</para></li><li><para><c>zone-id</c> - The ID of the Availability Zone (for example, <c>use1-az1</c>),
        /// the Local Zone (for example, <c>usw2-lax1-az1</c>), or the Wavelength Zone (for example,
        /// <c>us-east-1-wl1-bos-wlz-1</c>).</para></li><li><para><c>zone-name</c> - The name of the Availability Zone (for example, <c>us-east-1a</c>),
        /// the Local Zone (for example, <c>us-west-2-lax-1a</c>), or the Wavelength Zone (for
        /// example, <c>us-east-1-wl1-bos-wlz-1</c>).</para></li><li><para><c>zone-type</c> - The type of zone (<c>availability-zone</c> | <c>local-zone</c>
        /// | <c>wavelength-zone</c>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ZoneId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Availability Zones, Local Zones, and Wavelength Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ZoneIds")]
        public System.String[] ZoneId { get; set; }
        #endregion
        
        #region Parameter ZoneName
        /// <summary>
        /// <para>
        /// <para>The names of the Availability Zones, Local Zones, and Wavelength Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ZoneNames")]
        public System.String[] ZoneName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AvailabilityZones'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeAvailabilityZonesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeAvailabilityZonesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AvailabilityZones";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeAvailabilityZonesResponse, GetEC2AvailabilityZoneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllAvailabilityZone = this.AllAvailabilityZone;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.ZoneId != null)
            {
                context.ZoneId = new List<System.String>(this.ZoneId);
            }
            if (this.ZoneName != null)
            {
                context.ZoneName = new List<System.String>(this.ZoneName);
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
            
            if (cmdletContext.AllAvailabilityZone != null)
            {
                request.AllAvailabilityZones = cmdletContext.AllAvailabilityZone.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.ZoneId != null)
            {
                request.ZoneIds = cmdletContext.ZoneId;
            }
            if (cmdletContext.ZoneName != null)
            {
                request.ZoneNames = cmdletContext.ZoneName;
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
        
        private Amazon.EC2.Model.DescribeAvailabilityZonesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeAvailabilityZonesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeAvailabilityZones");
            try
            {
                #if DESKTOP
                return client.DescribeAvailabilityZones(request);
                #elif CORECLR
                return client.DescribeAvailabilityZonesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllAvailabilityZone { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public List<System.String> ZoneId { get; set; }
            public List<System.String> ZoneName { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeAvailabilityZonesResponse, GetEC2AvailabilityZoneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AvailabilityZones;
        }
        
    }
}
