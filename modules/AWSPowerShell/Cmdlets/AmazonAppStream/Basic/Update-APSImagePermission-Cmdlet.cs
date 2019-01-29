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
    /// Adds or updates permissions for the specified private image.
    /// </summary>
    [Cmdlet("Update", "APSImagePermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS AppStream UpdateImagePermissions API operation.", Operation = new[] {"UpdateImagePermissions"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Name parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AppStream.Model.UpdateImagePermissionsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAPSImagePermissionCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter ImagePermissions_AllowFleet
        /// <summary>
        /// <para>
        /// <para>Indicates whether the image can be used for a fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ImagePermissions_AllowFleet { get; set; }
        #endregion
        
        #region Parameter ImagePermissions_AllowImageBuilder
        /// <summary>
        /// <para>
        /// <para>Indicates whether the image can be used for an image builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ImagePermissions_AllowImageBuilder { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the private image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SharedAccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit identifier of the AWS account for which you want add or update image
        /// permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SharedAccountId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Name parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APSImagePermission (UpdateImagePermissions)"))
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
            
            if (ParameterWasBound("ImagePermissions_AllowFleet"))
                context.ImagePermissions_AllowFleet = this.ImagePermissions_AllowFleet;
            if (ParameterWasBound("ImagePermissions_AllowImageBuilder"))
                context.ImagePermissions_AllowImageBuilder = this.ImagePermissions_AllowImageBuilder;
            context.Name = this.Name;
            context.SharedAccountId = this.SharedAccountId;
            
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
            var request = new Amazon.AppStream.Model.UpdateImagePermissionsRequest();
            
            
             // populate ImagePermissions
            bool requestImagePermissionsIsNull = true;
            request.ImagePermissions = new Amazon.AppStream.Model.ImagePermissions();
            System.Boolean? requestImagePermissions_imagePermissions_AllowFleet = null;
            if (cmdletContext.ImagePermissions_AllowFleet != null)
            {
                requestImagePermissions_imagePermissions_AllowFleet = cmdletContext.ImagePermissions_AllowFleet.Value;
            }
            if (requestImagePermissions_imagePermissions_AllowFleet != null)
            {
                request.ImagePermissions.AllowFleet = requestImagePermissions_imagePermissions_AllowFleet.Value;
                requestImagePermissionsIsNull = false;
            }
            System.Boolean? requestImagePermissions_imagePermissions_AllowImageBuilder = null;
            if (cmdletContext.ImagePermissions_AllowImageBuilder != null)
            {
                requestImagePermissions_imagePermissions_AllowImageBuilder = cmdletContext.ImagePermissions_AllowImageBuilder.Value;
            }
            if (requestImagePermissions_imagePermissions_AllowImageBuilder != null)
            {
                request.ImagePermissions.AllowImageBuilder = requestImagePermissions_imagePermissions_AllowImageBuilder.Value;
                requestImagePermissionsIsNull = false;
            }
             // determine if request.ImagePermissions should be set to null
            if (requestImagePermissionsIsNull)
            {
                request.ImagePermissions = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SharedAccountId != null)
            {
                request.SharedAccountId = cmdletContext.SharedAccountId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.Name;
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
        
        private Amazon.AppStream.Model.UpdateImagePermissionsResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.UpdateImagePermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppStream", "UpdateImagePermissions");
            try
            {
                #if DESKTOP
                return client.UpdateImagePermissions(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateImagePermissionsAsync(request);
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
            public System.Boolean? ImagePermissions_AllowFleet { get; set; }
            public System.Boolean? ImagePermissions_AllowImageBuilder { get; set; }
            public System.String Name { get; set; }
            public System.String SharedAccountId { get; set; }
        }
        
    }
}
