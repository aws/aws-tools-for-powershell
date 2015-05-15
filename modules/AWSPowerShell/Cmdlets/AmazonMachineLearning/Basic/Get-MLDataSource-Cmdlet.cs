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
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Returns a <code>DataSource</code> that includes metadata and data file information,
    /// as well as the current status of the <code>DataSource</code>.
    /// 
    ///  
    /// <para><code>GetDataSource</code> provides results in normal or verbose format. The verbose
    /// format adds the schema description and the list of files pointed to by the DataSource
    /// to the normal format.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "MLDataSource")]
    [OutputType("Amazon.MachineLearning.Model.GetDataSourceResult")]
    [AWSCmdlet("Invokes the GetDataSource operation against Amazon Machine Learning.", Operation = new[] {"GetDataSource"})]
    [AWSCmdletOutput("Amazon.MachineLearning.Model.GetDataSourceResult",
        "This cmdlet returns a GetDataSourceResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetMLDataSourceCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The ID assigned to the <code>DataSource</code> at creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSourceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies whether the <code>GetDataSource</code> operation should return <code>DataSourceSchema</code>.</para><para>If true, <code>DataSourceSchema</code> is returned.</para><para>If false, <code>DataSourceSchema</code> is not returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean VerboseResponse { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DataSourceId = this.DataSourceId;
            if (ParameterWasBound("VerboseResponse"))
                context.VerboseResponse = this.VerboseResponse;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetDataSourceRequest();
            
            if (cmdletContext.DataSourceId != null)
            {
                request.DataSourceId = cmdletContext.DataSourceId;
            }
            if (cmdletContext.VerboseResponse != null)
            {
                request.Verbose = cmdletContext.VerboseResponse.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetDataSource(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
            public String DataSourceId { get; set; }
            public Boolean? VerboseResponse { get; set; }
        }
        
    }
}
