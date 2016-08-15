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
    /// Purchases a reserved DB instance offering.
    /// </summary>
    [Cmdlet("Get", "RDSReservedDBInstancesOffering")]
    [OutputType("Amazon.RDS.Model.ReservedDBInstance")]
    [AWSCmdlet("Invokes the PurchaseReservedDBInstancesOffering operation against Amazon Relational Database Service.", Operation = new[] {"PurchaseReservedDBInstancesOffering"})]
    [AWSCmdletOutput("Amazon.RDS.Model.ReservedDBInstance",
        "This cmdlet returns a ReservedDBInstance object.",
        "The service call response (type Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRDSReservedDBInstancesOfferingCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBInstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances to reserve.</para><para>Default: <code>1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DBInstanceCount { get; set; }
        #endregion
        
        #region Parameter ReservedDBInstanceId
        /// <summary>
        /// <para>
        /// <para>Customer-specified identifier to track this reservation.</para><para>Example: myreservationID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReservedDBInstanceId { get; set; }
        #endregion
        
        #region Parameter ReservedDBInstancesOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the Reserved DB instance offering to purchase.</para><para>Example: 438012d3-4052-4cc7-b2e3-8d3372e0e706</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReservedDBInstancesOfferingId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
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
            
            if (ParameterWasBound("DBInstanceCount"))
                context.DBInstanceCount = this.DBInstanceCount;
            context.ReservedDBInstanceId = this.ReservedDBInstanceId;
            context.ReservedDBInstancesOfferingId = this.ReservedDBInstancesOfferingId;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
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
            var request = new Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingRequest();
            
            if (cmdletContext.DBInstanceCount != null)
            {
                request.DBInstanceCount = cmdletContext.DBInstanceCount.Value;
            }
            if (cmdletContext.ReservedDBInstanceId != null)
            {
                request.ReservedDBInstanceId = cmdletContext.ReservedDBInstanceId;
            }
            if (cmdletContext.ReservedDBInstancesOfferingId != null)
            {
                request.ReservedDBInstancesOfferingId = cmdletContext.ReservedDBInstancesOfferingId;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReservedDBInstance;
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
        
        private static Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.PurchaseReservedDBInstancesOfferingRequest request)
        {
            #if DESKTOP
            return client.PurchaseReservedDBInstancesOffering(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PurchaseReservedDBInstancesOfferingAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? DBInstanceCount { get; set; }
            public System.String ReservedDBInstanceId { get; set; }
            public System.String ReservedDBInstancesOfferingId { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
        }
        
    }
}
