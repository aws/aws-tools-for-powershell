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
    /// Returns a list of parameter settings for the specified parameter group family. 
    /// 
    ///  
    /// <para>
    ///  For more information about parameters and parameter groups, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-parameter-groups.html">Amazon
    /// Redshift Parameter Groups</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "RSDefaultClusterParameters")]
    [OutputType("Amazon.Redshift.Model.DefaultClusterParameters")]
    [AWSCmdlet("Invokes the DescribeDefaultClusterParameters operation against Amazon Redshift.", Operation = new[] {"DescribeDefaultClusterParameters"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.DefaultClusterParameters",
        "This cmdlet returns a DefaultClusterParameters object.",
        "The service call response (type DescribeDefaultClusterParametersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetRSDefaultClusterParametersCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The name of the cluster parameter group family. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String ParameterGroupFamily { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> An optional parameter that specifies the starting point to return a set of response
        /// records. When the results of a <a>DescribeDefaultClusterParameters</a> request exceed
        /// the value specified in <code>MaxRecords</code>, AWS returns a value in the <code>Marker</code>
        /// field of the response. You can retrieve the next set of response records by providing
        /// the returned marker value in the <code>Marker</code> parameter and retrying the request.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The maximum number of response records to return in each call. If the number of remaining
        /// response records exceeds the specified <code>MaxRecords</code> value, a value is returned
        /// in a <code>marker</code> field of the response. You can retrieve the next set of records
        /// by retrying the command with the returned marker value. </para><para>Default: <code>100</code></para><para>Constraints: minimum 20, maximum 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            context.ParameterGroupFamily = this.ParameterGroupFamily;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeDefaultClusterParametersRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxRecords != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecords.Value);
            }
            if (cmdletContext.ParameterGroupFamily != null)
            {
                request.ParameterGroupFamily = cmdletContext.ParameterGroupFamily;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeDefaultClusterParameters(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DefaultClusterParameters;
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
            public String Marker { get; set; }
            public int? MaxRecords { get; set; }
            public String ParameterGroupFamily { get; set; }
        }
        
    }
}
