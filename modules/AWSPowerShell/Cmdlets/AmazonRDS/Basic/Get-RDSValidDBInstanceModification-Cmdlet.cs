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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// You can call <a>DescribeValidDBInstanceModifications</a> to learn what modifications
    /// you can make to your DB instance. You can use this information when you call <a>ModifyDBInstance</a>.
    /// </summary>
    [Cmdlet("Get", "RDSValidDBInstanceModification")]
    [OutputType("Amazon.RDS.Model.ValidDBInstanceModificationsMessage")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeValidDBInstanceModifications API operation.", Operation = new[] {"DescribeValidDBInstanceModifications"})]
    [AWSCmdletOutput("Amazon.RDS.Model.ValidDBInstanceModificationsMessage",
        "This cmdlet returns a ValidDBInstanceModificationsMessage object.",
        "The service call response (type Amazon.RDS.Model.DescribeValidDBInstanceModificationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRDSValidDBInstanceModificationCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The customer identifier or the ARN of your DB instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBInstanceIdentifier { get; set; }
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
            
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            
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
            var request = new Amazon.RDS.Model.DescribeValidDBInstanceModificationsRequest();
            
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ValidDBInstanceModificationsMessage;
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
        
        private Amazon.RDS.Model.DescribeValidDBInstanceModificationsResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeValidDBInstanceModificationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeValidDBInstanceModifications");
            try
            {
                #if DESKTOP
                return client.DescribeValidDBInstanceModifications(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeValidDBInstanceModificationsAsync(request);
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
            public System.String DBInstanceIdentifier { get; set; }
        }
        
    }
}
