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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Creates a new DB cluster parameter group.
    /// 
    ///  
    /// <para>
    /// Parameters in a DB cluster parameter group apply to all of the instances in a DB cluster.
    /// </para><para>
    /// A DB cluster parameter group is initially created with the default parameters for
    /// the database engine used by instances in the DB cluster. To provide custom values
    /// for any of the parameters, you must modify the group after you create it. After you
    /// create a DB cluster parameter group, you must associate it with your DB cluster. For
    /// the new DB cluster parameter group and associated settings to take effect, you must
    /// then reboot the DB instances in the DB cluster without failover.
    /// </para><important><para>
    /// After you create a DB cluster parameter group, you should wait at least 5 minutes
    /// before creating your first DB cluster that uses that DB cluster parameter group as
    /// the default parameter group. This allows Amazon DocumentDB to fully complete the create
    /// action before the DB cluster parameter group is used as the default for a new DB cluster.
    /// This step is especially important for parameters that are critical when creating the
    /// default database for a DB cluster, such as the character set for the default database
    /// defined by the <code>character_set_database</code> parameter.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "DOCDBClusterParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.DBClusterParameterGroup")]
    [AWSCmdlet("Calls the Amazon DocumentDB CreateDBClusterParameterGroup API operation.", Operation = new[] {"CreateDBClusterParameterGroup"})]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBClusterParameterGroup",
        "This cmdlet returns a DBClusterParameterGroup object.",
        "The service call response (type Amazon.DocDB.Model.CreateDBClusterParameterGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDOCDBClusterParameterGroupCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        #region Parameter DBClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB cluster parameter group.</para><para>Constraints:</para><ul><li><para>Must match the name of an existing <code>DBClusterParameterGroup</code>.</para></li></ul><note><para>This value is stored as a lowercase string.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DBClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBParameterGroupFamily
        /// <summary>
        /// <para>
        /// <para>The DB cluster parameter group family name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DBParameterGroupFamily { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for the DB cluster parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the DB cluster parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DocDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBClusterParameterGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DOCDBClusterParameterGroup (CreateDBClusterParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            context.DBParameterGroupFamily = this.DBParameterGroupFamily;
            context.Description = this.Description;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DocDB.Model.Tag>(this.Tag);
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
            var request = new Amazon.DocDB.Model.CreateDBClusterParameterGroupRequest();
            
            if (cmdletContext.DBClusterParameterGroupName != null)
            {
                request.DBClusterParameterGroupName = cmdletContext.DBClusterParameterGroupName;
            }
            if (cmdletContext.DBParameterGroupFamily != null)
            {
                request.DBParameterGroupFamily = cmdletContext.DBParameterGroupFamily;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
                object pipelineOutput = response.DBClusterParameterGroup;
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
        
        private Amazon.DocDB.Model.CreateDBClusterParameterGroupResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.CreateDBClusterParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB", "CreateDBClusterParameterGroup");
            try
            {
                #if DESKTOP
                return client.CreateDBClusterParameterGroup(request);
                #elif CORECLR
                return client.CreateDBClusterParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String DBClusterParameterGroupName { get; set; }
            public System.String DBParameterGroupFamily { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.DocDB.Model.Tag> Tags { get; set; }
        }
        
    }
}
