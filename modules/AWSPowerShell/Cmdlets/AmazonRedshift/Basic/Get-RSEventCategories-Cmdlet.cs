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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Displays a list of event categories for all event source types, or for a specified
    /// source type. For a list of the event categories and source types, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-event-notifications.html">Amazon
    /// Redshift Event Notifications</a>.
    /// </summary>
    [Cmdlet("Get", "RSEventCategories")]
    [OutputType("Amazon.Redshift.Model.EventCategoriesMap")]
    [AWSCmdlet("Invokes the DescribeEventCategories operation against Amazon Redshift.", Operation = new[] {"DescribeEventCategories"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.EventCategoriesMap",
        "This cmdlet returns a collection of EventCategoriesMap objects.",
        "The service call response (type Amazon.Redshift.Model.DescribeEventCategoriesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetRSEventCategoriesCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para> The source type, such as cluster or parameter group, to which the described event
        /// categories apply. </para><para> Valid values: cluster, cluster-snapshot, cluster-parameter-group, and cluster-security-group.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceType { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.SourceType = this.SourceType;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Redshift.Model.DescribeEventCategoriesRequest();
            
            if (cmdletContext.SourceType != null)
            {
                request.SourceType = cmdletContext.SourceType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeEventCategories(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EventCategoriesMapList;
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
            public System.String SourceType { get; set; }
        }
        
    }
}
