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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Associates the specified users with the specified stacks. Users in a user pool cannot
    /// be assigned to stacks with fleets that are joined to an Active Directory domain.
    /// </summary>
    [Cmdlet("Register", "APSUserStackBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.UserStackAssociationError")]
    [AWSCmdlet("Calls the AWS AppStream BatchAssociateUserStack API operation.", Operation = new[] {"BatchAssociateUserStack"})]
    [AWSCmdletOutput("Amazon.AppStream.Model.UserStackAssociationError",
        "This cmdlet returns a collection of UserStackAssociationError objects.",
        "The service call response (type Amazon.AppStream.Model.BatchAssociateUserStackResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterAPSUserStackBatchCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter UserStackAssociation
        /// <summary>
        /// <para>
        /// <para>The list of UserStackAssociation objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("UserStackAssociations")]
        public Amazon.AppStream.Model.UserStackAssociation[] UserStackAssociation { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserStackAssociation", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-APSUserStackBatch (BatchAssociateUserStack)"))
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
            
            if (this.UserStackAssociation != null)
            {
                context.UserStackAssociations = new List<Amazon.AppStream.Model.UserStackAssociation>(this.UserStackAssociation);
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
            var request = new Amazon.AppStream.Model.BatchAssociateUserStackRequest();
            
            if (cmdletContext.UserStackAssociations != null)
            {
                request.UserStackAssociations = cmdletContext.UserStackAssociations;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Errors;
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
        
        private Amazon.AppStream.Model.BatchAssociateUserStackResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.BatchAssociateUserStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppStream", "BatchAssociateUserStack");
            try
            {
                #if DESKTOP
                return client.BatchAssociateUserStack(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.BatchAssociateUserStackAsync(request);
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
            public List<Amazon.AppStream.Model.UserStackAssociation> UserStackAssociations { get; set; }
        }
        
    }
}
