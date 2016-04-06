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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// This action returns the status and changes of a change batch request.
    /// <br/><b>NOTE: This operation is deprecated because it is an experimental feature not intended for use. The
    /// cmdlet will be removed in a future release.</b>
    /// </summary>
    [Cmdlet("Get", "R53ChangeDetails")]
    [OutputType("Amazon.Route53.Model.ChangeBatchRecord")]
    [AWSCmdlet("Invokes the GetChangeDetails operation against Amazon Route 53.", Operation = new[] {"GetChangeDetails"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ChangeBatchRecord",
        "This cmdlet returns a ChangeBatchRecord object.",
        "The service call response (type Amazon.Route53.Model.GetChangeDetailsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetR53ChangeDetailsCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {

        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the change batch request. The value that you specify here is the value that
        /// <code>ChangeResourceRecordSets</code> returned in the Id element when you submitted
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };

            context.Id = this.Id;

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.GetChangeDetailsRequest();

            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }

            CmdletOutput output;

            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetChangeDetails(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ChangeBatchRecord;
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
            public System.String Id { get; set; }
        }

    }
}
