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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Looks up API activity events captured by CloudTrail that create, update, or delete
    /// resources in your account. Events for a region can be looked up for the times in which
    /// you had CloudTrail turned on in that region during the last seven days. Lookup supports
    /// five different attributes: time range (defined by a start time and end time), user
    /// name, event name, resource type, and resource name. All attributes are optional. The
    /// maximum number of attributes that can be specified in any one lookup request are time
    /// range and one other attribute. The default number of results returned is 10, with
    /// a maximum of 50 possible. The response includes a token that you can use to get the
    /// next page of results. 
    /// 
    ///  <important>The rate of lookup requests is limited to one per second per account.
    /// If this limit is exceeded, a throttling error occurs. </important><important>Events
    /// that occurred during the selected time range will not be available for lookup if CloudTrail
    /// logging was not enabled when the events occurred.</important>
    /// </summary>
    [Cmdlet("Find", "CTEvents")]
    [OutputType("Amazon.CloudTrail.Model.Event")]
    [AWSCmdlet("Invokes the LookupEvents operation against AWS CloudTrail.", Operation = new[] {"LookupEvents"})]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.Event",
        "This cmdlet returns a collection of Event objects.",
        "The service call response (type Amazon.CloudTrail.Model.LookupEventsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class FindCTEventsCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>Specifies that only events that occur before or at the specified time are returned.
        /// If the specified end time is before the specified start time, an error is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter LookupAttribute
        /// <summary>
        /// <para>
        /// <para>Contains a list of lookup attributes. Currently the list can contain only one item.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LookupAttributes")]
        public Amazon.CloudTrail.Model.LookupAttribute[] LookupAttribute { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>Specifies that only events that occur after or at the specified time are returned.
        /// If the specified start time is after the specified end time, an error is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The number of events to return. Possible values are 1 through 50. The default is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to use to get the next page of results after a previous API call. This token
        /// must be passed in with the same parameters that were specified in the the original
        /// call. For example, if the original call specified an AttributeKey of 'Username' with
        /// a value of 'root', the call with NextToken should include those same parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            if (this.LookupAttribute != null)
            {
                context.LookupAttributes = new List<Amazon.CloudTrail.Model.LookupAttribute>(this.LookupAttribute);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudTrail.Model.LookupEventsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.LookupAttributes != null)
            {
                request.LookupAttributes = cmdletContext.LookupAttributes;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.LookupEvents(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Events;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
            public System.DateTime? EndTime { get; set; }
            public List<Amazon.CloudTrail.Model.LookupAttribute> LookupAttributes { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
