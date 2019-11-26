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
    /// Describes the Availability Zones and Local Zones that are available to you. If there
    /// is an event impacting an Availability Zone or Local Zone, you can use this request
    /// to view the state and any provided messages for that Availability Zone or Local Zone.
    /// 
    ///  
    /// <para>
    /// For more information about Availability Zones and Local Zones, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-regions-availability-zones.html">Regions
    /// and Availability Zones</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2AvailabilityZone")]
    [OutputType("Amazon.EC2.Model.AvailabilityZone")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeAvailabilityZones API operation.", Operation = new[] {"DescribeAvailabilityZones"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeAvailabilityZonesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.AvailabilityZone or Amazon.EC2.Model.DescribeAvailabilityZonesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.AvailabilityZone objects.",
        "The service call response (type Amazon.EC2.Model.DescribeAvailabilityZonesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2AvailabilityZoneCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AllAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Include all Availability Zones and Local Zones regardless of your opt in status.</para><para>If you do not use this parameter, the results include only the zones for the Regions
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
        /// <para>The filters.</para><ul><li><para><code>group-name</code> - For Availability Zones, use the Region name. For Local
        /// Zones, use the name of the group associated with the Local Zone (for example, <code>us-west-2-lax-1</code>).</para></li><li><para><code>message</code> - The Availability Zone or Local Zone message.</para></li><li><para><code>opt-in-status</code> - The opt in status (<code>opted-in</code>, and <code>not-opted-in</code>
        /// | <code>opt-in-not-required</code>).</para></li><li><para><code>region-name</code> - The name of the Region for the Availability Zone or Local
        /// Zone (for example, <code>us-east-1</code>).</para></li><li><para><code>state</code> - The state of the Availability Zone or Local Zone (<code>available</code>
        /// | <code>information</code> | <code>impaired</code> | <code>unavailable</code>).</para></li><li><para><code>zone-id</code> - The ID of the Availability Zone (for example, <code>use1-az1</code>)
        /// or the Local Zone (for example, use <code>usw2-lax1-az1</code>).</para></li><li><para><code>zone-name</code> - The name of the Availability Zone (for example, <code>us-east-1a</code>)
        /// or the Local Zone (for example, use <code>us-west-2-lax-1a</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ZoneId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Availability Zones and Local Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ZoneIds")]
        public System.String[] ZoneId { get; set; }
        #endregion
        
        #region Parameter ZoneName
        /// <summary>
        /// <para>
        /// <para>The names of the Availability Zones and Local Zones.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ZoneName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ZoneName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ZoneName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeAvailabilityZonesResponse, GetEC2AvailabilityZoneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ZoneName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
